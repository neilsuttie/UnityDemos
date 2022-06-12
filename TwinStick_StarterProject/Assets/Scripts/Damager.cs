using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [Tooltip("how much damage does this object cause?")]
    public int damage;

    [Tooltip("The object type we want to cause damage too")]
    public string targetTag;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
     
        }
    }
}
