using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuanchObject : MonoBehaviour
{

    [SerializeField] GameObject objectPrefab;
    [SerializeField] Vector3 force;
    
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (objectPrefab != null && objectPrefab.GetComponent<Rigidbody>())
            {
                GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);


                Rigidbody[] Rigidbodies = newObject.GetComponentsInChildren<Rigidbody>();

                foreach(Rigidbody body in Rigidbodies)
                {
                    body.AddForce(force, ForceMode.Impulse);
                }
            }
        }
    }
}
