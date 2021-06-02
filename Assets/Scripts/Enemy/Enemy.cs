using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAI))]
public class Enemy : MonoBehaviour
{
    [SerializeField] internal Transform target;

    internal EnemyAI enemyAI;

    internal NavMeshAgent navMeshAgent;


    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        enemyAI.CustomAwake();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }
}