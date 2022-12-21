using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 10f;

    // Max rotation of object
    public float maxRotation = 45f;

    // Starting rotation of the object
    private float startRotation;

    void Start()
    {
        // Record the starting rotation
        startRotation = transform.rotation.z;
    }

    void Update()
    {
        // Calculate the desired rotation
        float desiredRotation = startRotation + maxRotation;

        // Rotate the object towards the desired rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, desiredRotation), rotationSpeed * Time.deltaTime);

        // If the object has reached the desired rotation, stop rotating
        if (Mathf.Approximately(transform.rotation.z, desiredRotation))
        {
            enabled = false;
        }
    }
}