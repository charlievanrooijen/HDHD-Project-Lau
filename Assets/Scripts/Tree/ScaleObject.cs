using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public Vector3 minScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(2, 2, 2);
    public float speed = 1.0f;

    private Vector3 targetScale;
    private Vector3 baseScale;
    private bool scalingUp = true;

    void Start()
    {
        baseScale = transform.localScale;
        targetScale = maxScale;
    }

    void Update()
    {
        // Scale the object up or down
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);

        // Check if the scale is close to the target scale
        if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
        {
            if (scalingUp)
            {
                targetScale = minScale;
                scalingUp = false;
            }
            else
            {
                targetScale = maxScale;
                scalingUp = true;
            }
        }
    }
}
