using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Header("Physics Settings")]
    public float myForce = 10f;

    private Rigidbody myRigidbody;

    public float lifeTime = 3f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.AddForce(transform.forward * myForce, ForceMode.Impulse);

        Invoke("Despawn", lifeTime);
    }

    private void Despawn()
    {
         Destroy(gameObject);
    }
}
