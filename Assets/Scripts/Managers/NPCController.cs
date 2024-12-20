using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    public NavMeshAgent m_NavMeshAgent { get; private set; }

    public NPCPatrol patrolPath;
    public int m_PathDestinationNodeIndex = 0;
    private Vector3 moveDirection;

    [SerializeField] Animator NPCANim;
    public string AnimState;
    private int state = ANIMSTATE_IDLE;

    const int ANIMSTATE_IDLE = 0;
    const int ANIMSTATE_WALK = 1;

    void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_PathDestinationNodeIndex = Random.Range(0, patrolPath.pathNodes.Count);
    }

    void Update()
    {
        m_PathDestinationNodeIndex = patrolPath.UpdatePathDestination(gameObject.transform, m_PathDestinationNodeIndex);

        Vector3 nextDestination = patrolPath.GetDestinationOnPath(gameObject.transform, m_PathDestinationNodeIndex);

        SetNavDestination(nextDestination);

        HandleNPCAnim();
    }

    public void SetNavDestination(Vector3 destination)
    {
        if (m_NavMeshAgent.enabled)
        {
            m_NavMeshAgent.SetDestination(destination);
        }
    }
    void HandleNPCAnim()
    {
        moveDirection = this.transform.position;

        if (moveDirection.sqrMagnitude > 0 && PlayerController.Instance.isEmpty)
        {
            ChangeAnimationState("Walk", 1);
        }
        else if (moveDirection.sqrMagnitude == 0 && PlayerController.Instance.isEmpty)
        {
            ChangeAnimationState("Idle", 0);
        }
    }

    public void ChangeAnimationState(string newState, int newStateID)
    {
        if (state == newStateID) return;

        state = newStateID;
        AnimState = newState;
        NPCANim.CrossFade(AnimState, 0.1f);

        Debug.Log($"Animation changed to: {AnimState}");
    }
}