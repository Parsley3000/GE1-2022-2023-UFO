using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Public variables
    public float laserRange = 100f; // The range of the laser
    public float laserWidth = 0.1f; // The width of the laser
    public Color laserColor = Color.blue; // The color of the laser
    public AudioSource moo1;
    public AudioSource moo2;
    public AudioSource laserSound;
    private Boolean mooSelect = true;
    private Boolean skipLaserSound = true;

    // Private variables
    private LineRenderer laserLine; // Reference to the line renderer component
    private RaycastHit hit; // Raycast hit information

    void Start()
    {
        // Get the line renderer component
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            // Enable the line renderer and shoot the laser
            laserLine.enabled = true;
            ShootLaser();
        }
        else
        {
            // Disable the line renderer
            laserLine.enabled = false;
            if (skipLaserSound == false) {
                laserSound.Play();
            }
            skipLaserSound = false;
            
        }
    }

    void ShootLaser()
    {
        // Set the start position of the laser to the position of the object
        laserLine.SetPosition(0, transform.position);

        // Check if the laser hits anything
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserRange))
        {
            // Set the end position of the laser to the hit point
            laserLine.SetPosition(1, hit.point);

            // Check if the hit object has a "Destroyable" tag
            if (hit.collider.CompareTag("Destroyable"))
            {
                // Destroy the hit object
                Destroy(hit.collider.gameObject);
                if (mooSelect == true)
                {
                    moo1.Play();
                    mooSelect = false;
                }
                else
                {
                    moo2.Play();
                    mooSelect = true;
                }
                
            }
        }
        else
        {
            // Set the end position of the laser to the maximum range
            laserLine.SetPosition(1, transform.position + (transform.forward * laserRange));
        }

        // Set the width and color of the laser
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
        laserLine.startColor = laserColor;
        laserLine.endColor = laserColor;
    }
}