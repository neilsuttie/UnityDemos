using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshWithTarget : MonoBehaviour
{

    private NavMeshAgent myNavMeshAgent;

    [Tooltip("The object to follow. If none then fetches the first object with target tag")]
    public Transform myTarget;

    public string myTargetTag = "Default";

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    
        if(myTarget == null && GameObject.FindGameObjectWithTag(myTargetTag))
        {
            myTarget = GameObject.FindGameObjectWithTag(myTargetTag).transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null)
            myNavMeshAgent.SetDestination(myTarget.transform.position);
    }
}
