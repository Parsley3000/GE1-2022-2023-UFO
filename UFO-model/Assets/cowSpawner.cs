using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int numPrefabs = 10;

    void Start()
    {
        float rotation = 0;
        for (int i = 0; i < numPrefabs; i++)
        {
            float x = Random.Range(0, 20);
            float z = Random.Range(0, 20);
            Vector3 pos = new Vector3(x, 2, z);
            Quaternion rot = Quaternion.Euler(0, rotation, 0);
            Instantiate(prefab, pos, rot);
            rotation += 60;
        }
    }
}