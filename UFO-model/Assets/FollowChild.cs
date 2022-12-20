using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChild : MonoBehaviour
{
    public Transform child; // the child object to follow

    void Update()
    {
        // set the position of the parent object to the position of the child object
        transform.position = child.position;
        transform.eulerAngles = new Vector3(0, child.eulerAngles.y, 0);
    }
}
