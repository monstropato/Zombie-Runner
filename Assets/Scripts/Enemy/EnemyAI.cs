using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;

    Enemy enemy;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    internal void CustomAwake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(enemy.target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= enemy.navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        enemy.navMeshAgent.SetDestination(enemy.target.position);
    }

    private void AttackTarget()
    {
        Debug.Log($"{gameObject.name} is attacking the {enemy.target.name}!");
    }


    //GIZMOS
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}