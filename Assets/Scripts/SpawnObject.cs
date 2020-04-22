using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public Camera cam;
    public Vector3 spawnOffset;
    
    void Start()
    {
        cam = Camera.main;
    }

    public void SetObject(GameObject obj)
    {
        objToSpawn = obj;
    }

    public void SpawnInWorld(GameObject obj)
    {
        objToSpawn = obj;
        Vector3 spawnPos = cam.transform.position + spawnOffset;

        GameObject objSpawned = Instantiate(objToSpawn, spawnPos, Quaternion.identity);
    }
}
