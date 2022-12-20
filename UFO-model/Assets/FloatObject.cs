using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public float movementSpeed = 1.0f; // control the speed at which the object moves up
    public bool moveUp = false; // control whether the object should move up or not

    void Start()
    {
        Debug.Log("FloatObject script started!");
    }

    void FixedUpdate()
    {
        if (moveUp)
        {
            Debug.Log("Moving up!");
            // move the object up by a certain amount each frame
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }

    }

    public void StopMoving()
    {
        moveUp = false;
    }
}
