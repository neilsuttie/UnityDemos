using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInDirection : MonoBehaviour
{
    public Transform targetPoint;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetPoint);
    }
}
