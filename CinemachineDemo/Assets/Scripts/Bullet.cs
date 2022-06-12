using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _force;

    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, _force, ForceMode.Impulse);
    }
}
