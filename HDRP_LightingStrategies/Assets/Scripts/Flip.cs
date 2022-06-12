using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private Vector3 _startPos;
    private Quaternion _startRot;

    public float _minForce = -10f;
    public float _maxForce = 10f;

    private Rigidbody _myRigidbody;
    private Vector3 _flipStrength;

    private void Start()
    {
        _startPos = gameObject.transform.position;
        _startRot = gameObject.transform.rotation;

        _myRigidbody = GetComponent<Rigidbody>();
    }

    public void FlipIt()
    {
        if(_myRigidbody)
        {
            _flipStrength = new Vector3(Random.Range(_minForce, _maxForce),
                Random.Range(_minForce, _maxForce)*2,
                Random.Range(_minForce, _maxForce));

            _myRigidbody.AddForce(_flipStrength, ForceMode.Impulse);
        }
    }

    public void Reset()
    {
        //Nulify the forces acting on the object
        _myRigidbody.velocity = Vector3.zero;
        _myRigidbody.angularVelocity = Vector3.zero;
        //Rest its position
        gameObject.transform.position = _startPos;
        gameObject.transform.rotation = _startRot;
    }
}
