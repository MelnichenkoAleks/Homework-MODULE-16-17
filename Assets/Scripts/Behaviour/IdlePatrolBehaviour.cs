using System.Collections.Generic;
using UnityEngine;

public class IdlePatrolBehaviour : IEnemyBehaviour
{
    private readonly Enemy _enemy;

    private readonly Transform[] _patrolPoints;

    private int _currentPointIndex = 0;

    public IdlePatrolBehaviour(Enemy enemy, List<Transform> patrolPoints)
    {
        _enemy = enemy;

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

    public void Enter()
    {
        _currentPointIndex = 0;
    }

    public void Update()
    {
        if (_patrolPoints.Length == 0) return;

        Transform currentTarget = _patrolPoints[_currentPointIndex];
        Vector3 direction = (currentTarget.position - _enemy.transform.position).normalized;
        float distance = Vector3.Distance(_enemy.transform.position, currentTarget.position);

        _enemy.ProcessRotateTo(direction);
        _enemy.ProcessMoveTo(direction);

        if (distance < 0.25f)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length;
        }
    }

    public void Exit()
    {
        _enemy.ProcessMoveTo(Vector3.zero);
    }
}
