using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile = null;
    public Transform spawnPoint = null ;

    public bool isLocked = true;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && isLocked == false)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if(spawnPoint != null)
        Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);

        Lock();
    }

    public void Lock()
    {
        isLocked = true;
    }
    public void Unlock()
    {
        isLocked = false;
    }

}
