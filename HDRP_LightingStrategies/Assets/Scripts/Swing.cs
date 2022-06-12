using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    private Vector3 _startingPos;
    private Quaternion _startingRot;

    private Rigidbody _myrigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _myrigidBody = GetComponent<Rigidbody>();

        _startingPos = _myrigidBody.position;
        _startingRot = _myrigidBody.rotation;
    }

    public void SwingIt()
    {
        if (_myrigidBody)
            _myrigidBody.AddForce(new Vector3(5, 0, 0), ForceMode.Impulse);
    }

    public void Reset()
    {
        _myrigidBody.velocity = Vector3.zero;
        _myrigidBody.angularVelocity = Vector3.zero;
        gameObject.transform.position = _startingPos;
        _myrigidBody.transform.rotation = _startingRot;
    }
}
