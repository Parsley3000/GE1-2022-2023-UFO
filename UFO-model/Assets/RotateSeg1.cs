using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSeg1 : MonoBehaviour
{
    // Rotation to apply when the object is created
    public float initialRotation = 45f;

    // Speed at which to rotate the object
    public float rotationSpeed = 10f;

    // Rotation applied to the object
    private float currentRotation;

    // Update is called once per frame
    void Update()
    {
        // Check if the "T" key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Rotate the object back to its original orientation
            transform.Rotate(-currentRotation * Time.deltaTime, 0, 0);
            currentRotation = 0;
        }
    }

    private void Start()
    {
        // Rotate the object on its z-axis
        transform.Rotate(0, 0, initialRotation * Time.deltaTime);
        currentRotation = initialRotation;
    }
}





