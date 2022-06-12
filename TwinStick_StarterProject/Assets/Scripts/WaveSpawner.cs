using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Tooltip("The prefab object to spawn")]
    public GameObject myObjectToSpawn;

    public GameObject[] mySpawnPoints;

    public float timeToStart = 1.0f;

    public float timeToRepeat = 5.0f;

    public float maximumEnemies = 20;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", timeToStart, timeToRepeat);
    }

    private void SpawnEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= maximumEnemies)
        {
            for (int i = 0; i < mySpawnPoints.Length; i++)
            {
                Instantiate(myObjectToSpawn, mySpawnPoints[i].transform.position, mySpawnPoints[i].transform.rotation);
            }
        }
    }
}
