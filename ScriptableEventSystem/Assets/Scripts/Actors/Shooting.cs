using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile = null;
    public Transform spawnPoint = null ;

    [Range(0, 100)] public float StartDelay;
    [Range(0, 100)] public float repeatRate;

    //TODO:Swap with coroutine.
    public void Draw()
    {
        InvokeRepeating("Fire", StartDelay, repeatRate);
    }

    private void Fire()
    {
        if(spawnPoint != null)
        Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

}
