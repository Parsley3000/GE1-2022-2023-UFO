using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndTilt : MonoBehaviour
{
    // Speed at which the object moves
    public float moveSpeed = 10.0f;

    // Maximum tilt angle
    public float maxTiltAngle = 15.0f;

    // Tilt speed
    public float tiltSpeed = 2.0f;

    // Current tilt angle
    private float currentTiltAngle = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the direction to move in
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        // Move the object
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Calculate the target tilt angle based on the direction of movement
        float targetTiltAngle = 0.0f;
        if (Mathf.Abs(horizontalInput) == Mathf.Abs(verticalInput))
        {
            targetTiltAngle = maxTiltAngle * ((horizontalInput + verticalInput) / 2);
            // Tilt the object towards the target tilt angle
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(currentTiltAngle, 0, currentTiltAngle);
        }
        else if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
        {
            // Tilt on the horizontal axis
            targetTiltAngle = maxTiltAngle * horizontalInput;
            // Tilt the object towards the target tilt angle
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0, 0, currentTiltAngle);
        }
        else
        {
            // Tilt on the vertical axis
            targetTiltAngle = maxTiltAngle * verticalInput;
            // Tilt the object towards the target tilt angle
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(currentTiltAngle, 0, 0);
        }
    }
}