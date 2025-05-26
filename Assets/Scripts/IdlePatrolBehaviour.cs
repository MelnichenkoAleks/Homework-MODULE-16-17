using System.Collections.Generic;
using UnityEngine;

public class IdlePatrolBehaviour : IEnemyIdleBehaviour
{
    private readonly Transform[] _patrolPoints;

    private int _currentPointIndex = 0;

    public IdlePatrolBehaviour(List<Transform> patrolPoints)
    {
        if (patrolPoints == null || patrolPoints.Count == 0)
        {
            Debug.LogWarning("Patrol points are not set.");
            _patrolPoints = new Transform[0];
        }
        else
        {
            _patrolPoints = patrolPoints.ToArray();
        }
    }

    public void EnemyIdleBehaviour(Enemy enemy)
    {
        if (_patrolPoints.Length == 0) return;

        Transform currentTarget = _patrolPoints[_currentPointIndex];

        Vector3 direction = (currentTarget.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(enemy.transform.position, currentTarget.position);

        enemy.ProcessRotateTo(direction);
        enemy.ProcessMoveTo(direction);

        if (distance < 0.25f)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length;
        }
    }
}
