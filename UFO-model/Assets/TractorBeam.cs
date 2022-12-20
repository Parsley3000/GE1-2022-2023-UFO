using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TractorBeam : MonoBehaviour
{
    // Public variables
    public float T_BeamRange = 100f; // The range of the T_Beam
    public float T_BeamWidth = 2f; // The width of the T_Beam
    public float T_BeamWidth_end = 3f;
    public float T_BeamAlpha = 0.5f; // The alpha value of the T_Beam's color (0 = transparent, 1 = opaque)

    // Private variables
    private LineRenderer T_BeamLine; // Reference to the line renderer component
    private RaycastHit hit; // Raycast hit information

    void Start()
    {
        // Get the line renderer component
        T_BeamLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButton(1))
        {
            // Enable the line renderer and shoot the T_Beam
            T_BeamLine.enabled = true;
            ShootT_Beam();
        }
        else
        {
            // Disable the line renderer
            T_BeamLine.enabled = false;
        }
    }

    void ShootT_Beam()
    {
        // Set the start position of the T_Beam to the position of the object
        T_BeamLine.SetPosition(0, transform.position);

        // Check if the T_Beam hits anything
        if (Physics.Raycast(transform.position, transform.forward, out hit, T_BeamRange))
        {
            // Set the end position of the T_Beam to the hit point
            T_BeamLine.SetPosition(1, hit.point);
        }
        else
        {
            // Set the end position of the T_Beam to the maximum range
            T_BeamLine.SetPosition(1, transform.position + (transform.forward * T_BeamRange));
        }

        // Set the width and color of the T_Beam
        T_BeamLine.startWidth = T_BeamWidth;
        T_BeamLine.endWidth = T_BeamWidth_end;
        T_BeamLine.startColor = new Color(1, 1, 1, T_BeamAlpha); // set the alpha value of the T_Beam's color
        T_BeamLine.endColor = new Color(1, 1, 1, T_BeamAlpha); // set the alpha value of the T_Beam's color
    }
}