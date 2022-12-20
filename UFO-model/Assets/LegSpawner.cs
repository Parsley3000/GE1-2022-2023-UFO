using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float angleIncrement = 120f;

    private List<GameObject> spawnedPrefabs;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (spawnedPrefabs != null && spawnedPrefabs.Count > 0)
            {
                // T key was pressed again, so delete the spawned prefabs
                foreach (GameObject spawnedPrefab in spawnedPrefabs)
                {
                    Destroy(spawnedPrefab);
                }
                spawnedPrefabs.Clear();
            }
            else
            {
                // T key was pressed for the first time, so spawn the prefabs
                spawnedPrefabs = new List<GameObject>();
                for (int i = 0; i < 3; i++)
                {
                    Quaternion rotation = Quaternion.Euler(0, angleIncrement * i, 0);
                    GameObject spawnedPrefab = Instantiate(prefab, transform.position, rotation, transform);
                    spawnedPrefabs.Add(spawnedPrefab);
                }
            }
        }
    }
}