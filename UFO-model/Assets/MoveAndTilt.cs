using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndTilt : MonoBehaviour
{
    public float speed = 10.0f;
    public float tiltAmount = 15.0f;
    public float tiltSmoothTime = 0.5f;

    private float tiltVelocityX;
    private float tiltVelocityZ;

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

        // Smoothly rotate the object
        transform.rotation = Quaternion.Euler(Mathf.SmoothDampAngle(transform.rotation.eulerAngles.x, tiltX, ref tiltVelocityX, tiltSmoothTime), 0, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, tiltZ, ref tiltVelocityZ, tiltSmoothTime));
    }
}