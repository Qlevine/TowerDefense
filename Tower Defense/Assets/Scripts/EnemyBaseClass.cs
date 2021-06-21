using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseClass : MonoBehaviour
{
    protected NavMeshAgent navAgent;
    [SerializeField]
    protected EnemySO enemySO;


    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = enemySO.speed;
    }

    public virtual void SetDestination(Vector3 destination)
    {
        if (navAgent)
        {
            navAgent.SetDestination(destination);
        }
    }
}
