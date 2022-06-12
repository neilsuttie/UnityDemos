using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public void SpawnWithDelay(float seconds)
    {
        Invoke("Spawn", seconds);
    }

    public void Spawn()
    {
        if (gameObject != null)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
}
