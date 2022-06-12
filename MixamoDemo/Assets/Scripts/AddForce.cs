using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour
{

    [SerializeField]
    Vector3 Force;

    private Rigidbody myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.AddForce(Force, ForceMode.Impulse);
    }
}
