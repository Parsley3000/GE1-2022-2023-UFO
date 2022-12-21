using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRotate : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // speed of rotation in degrees per second

    void Update()
    {
        // transform the y-axis vector from local to world space
        Vector3 yAxis = transform.parent.TransformDirection(Vector3.up);

        // rotate the object around the transformed y-axis
        transform.Rotate(yAxis * Time.deltaTime * rotationSpeed, Space.World);
    }
}