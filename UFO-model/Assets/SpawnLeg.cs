using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeg : MonoBehaviour
{
    // Prefab to spawn
    public GameObject prefab;

    // Parent object to spawn prefab as a child of
    public Transform parent;

    // Time to wait before destroying prefab
    public float destroyDelay = 3f;

    // Variable to store the spawned prefab
    private GameObject spawnedPrefab;

    // Update is called once per frame
    void Update()
    {
        // Check if the "T" key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // If the prefab has already been spawned
            if (spawnedPrefab != null)
            {
                // Destroy the prefab after the destroy delay
                Destroy(spawnedPrefab, destroyDelay);
            }
            else
            {
                // Spawn the prefab as a child of the parent object
                spawnedPrefab = Instantiate(prefab, parent.position, Quaternion.identity, parent);
            }
        }
    }
}