using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    [Tooltip("Lower is faster! Higher is slower!")]
    public float fireRate = 1f;
    private float timer = 0.00f;

    public Transform spawnPoint;

    private Rigidbody myRigidBody;

      // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (timer < fireRate) return;

        //Reset the timer everytime we fire
        timer = 0.00f;
        Instantiate(projectilePrefab, spawnPoint.transform.position, spawnPoint.rotation);
    }
}
