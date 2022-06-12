﻿using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshTarget : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public Transform targetMarker;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void UpdateTargets(Vector3 targetPosition)
    {
        navAgent.destination = targetPosition;
    }

    private void Update()
    {
        if (GetInput())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;
                UpdateTargets(targetPosition);
                targetMarker.position = targetPosition;
            }
        }
    }

    private bool GetInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(targetMarker.position, targetMarker.position + Vector3.up * 5, Color.red);
    }
}