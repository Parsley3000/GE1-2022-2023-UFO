using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndTilt : MonoBehaviour
{
    public float speed = 10.0f;
    public float tiltAmount = 15.0f;
    public float tiltSmoothTime = 5f;
    public float yRotation;
    public float yRotationAmount = 90f;

    // Add a new speed variable for the up and down movement
    public float upDownSpeed = 4.0f;

    // Add a new smooth time variable for the up and down movement
    public float upDownSmoothTime = 0.3f;

    private float tiltVelocityX;
    private float tiltVelocityZ;
    private Vector3 upDownVelocity = Vector3.zero;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Calculate the direction to move in
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        // Move the object
        transform.position += moveDirection * speed * Time.deltaTime;

        // Tilt on x axis when getting a vertical input
        float tiltX = 0.0f;
        if (verticalInput != 0)
        {
            tiltX = tiltAmount * verticalInput;
        }

        // Tilt on z axis when getting a horizontal input
        float tiltZ = 0.0f;
        if (horizontalInput != 0)
        {
            tiltZ = tiltAmount * horizontalInput;
        }

        if (Input.GetKey(KeyCode.Q)) // Check if the "q" key is being held down
        {
            yRotation -= yRotationAmount * Time.deltaTime; // Increase the value
        }
        else if (Input.GetKey(KeyCode.E)) // Check if the "e" key is being held down
        {
            yRotation += yRotationAmount * Time.deltaTime; // Decrease the value
        }

        // Smoothly rotate the object
        transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(transform.rotation.eulerAngles.x, tiltX, ref tiltVelocityX, tiltSmoothTime), yRotation, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, tiltZ, ref tiltVelocityZ, tiltSmoothTime));

        // Check if the space bar is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            // Set the target position to the current position with an added offset in the y direction
            Vector3 targetPosition = transform.position + Vector3.up;

            // Smoothly move the object to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref upDownVelocity, upDownSmoothTime);
        }
        // Check if the shift key is pressed
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            // Set the target position to the current position with a subtracted offset in the y direction
            Vector3 targetPosition = transform.position + Vector3.down;

            // Smoothly move the object to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref upDownVelocity, upDownSmoothTime);
        }
    }
}