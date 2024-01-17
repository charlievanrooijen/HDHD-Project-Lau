using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate around the z-axis
        transform.Rotate(0, rotationSpeed, 0 * Time.deltaTime);
    }
}
