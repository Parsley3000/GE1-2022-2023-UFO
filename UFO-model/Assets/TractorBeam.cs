using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    // The line renderer that will display the tractor beam
    private LineRenderer lineRenderer;
    public AudioSource teleport; 
    public AudioSource TBeam_warp_sound;
    private Boolean skipWarpSound = true;

    // The force with which the beam will pull objects towards its origin
    public float pullForce = 10f;

    // The thickness of the beam
    public float thickness = 2f;

    void Start()
    {
        // Get the line renderer component
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Only show the line renderer and apply the tractor beam if the left mouse button is held down
        if (Input.GetMouseButton(1))
        {
            // Update the line renderer to match the position of the beam
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100f);

            // Set the thickness of the beam
            lineRenderer.startWidth = thickness;
            lineRenderer.endWidth = thickness;

            // Cast a ray from the beam's origin in the direction of the beam
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // If the ray hits an object with the "Destroyable" tag, apply a force to it to pull it towards the beam's origin
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Destroyable")
                {
                    hitObject.GetComponent<Rigidbody>().AddForce((transform.position - hitObject.transform.position).normalized * pullForce);

                    // If the object is close enough to the beam's origin, destroy it
                    if (Vector3.Distance(transform.position, hitObject.transform.position) < 3f)
                    {
                        teleport.Play();
                        Destroy(hitObject);
                    }
                }
            }
        }
        else
        {
            // Hide the line renderer when the left mouse button is not held down
            lineRenderer.startWidth = 0f;
            lineRenderer.endWidth = 0f;
            if(skipWarpSound == false)
            {
                TBeam_warp_sound.Play();
            }
            skipWarpSound = false;
        }
    }
}





