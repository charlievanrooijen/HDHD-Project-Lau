using UnityEngine;

public class OscillateRotation : MonoBehaviour
{
    public float speed = 1.0f; // Speed of rotation
    public AudioClip soundClip; // The sound clip to play

    private float minAngle = -23f; // Minimum rotation angle
    private float maxAngle = 25f; // Maximum rotation angle
    private AudioSource audioSource; // Audio source component
    private float previousSinValue; // Track the previous frame's Sin value

    void Start()
    {
        // Get or add the AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = soundClip; // Set the audio clip
        previousSinValue = Mathf.Sin(Time.time * speed); // Initialize previousSinValue
    }

    void Update()
    {
        // Calculate the current frame's Sin value
        float currentSinValue = Mathf.Sin(Time.time * speed);

        // Check if the direction has changed
        if ((previousSinValue <= 0 && currentSinValue > 0) || (previousSinValue >= 0 && currentSinValue < 0))
        {
            audioSource.Play(); // Play the sound
        }

        // Update the previousSinValue for the next frame
        previousSinValue = currentSinValue;

        // Calculate the rotation angle
        float angle = Mathf.Lerp(minAngle, maxAngle, (currentSinValue + 1) / 2);

        // Apply the rotation around the X axis
        transform.localEulerAngles = new Vector3(angle, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
