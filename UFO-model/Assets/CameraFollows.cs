using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target; // The object that the camera should follow
    public float distance = -10f; // The distance of the camera from the target
    public float height = 5f; // The height of the camera above the target
    public float angle = 20f; // The angle at which the camera is pointing down towards the target

    void Update()
    {
        // Calculate the position and rotation of the camera based on the target's position and rotation
        Vector3 targetPos = target.position - (target.forward * distance);
        targetPos.y += height;
        Quaternion targetRot = Quaternion.Euler(angle, target.rotation.eulerAngles.y, 0f);

        // Set the position and rotation of the camera to match the calculated values
        transform.position = targetPos;
        transform.rotation = targetRot;
    }
}