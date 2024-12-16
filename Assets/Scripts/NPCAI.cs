using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] GameObject targetGO;

    private void Start()
    {
        agent =  GetComponent<NavMeshAgent>();
        agent.SetDestination(targetGO.transform.position);
    }
}
