using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Enemy _enemy;

    public List<Transform> patrolPoints;

    public IdleBehaviourTypes IdleBehaviourType;
    public AggroBehaviourTypes AggroBehaviourType;

    public Vector3 Position => transform.position;

    public bool IsEmpty
    {
        get
        {
            if (_enemy == null)
                return true;

            if (_enemy.gameObject == null)
                return true;

            return false;
        }
    }

    public void Occupy(Enemy enemy)
    {
        _enemy = enemy;
    }
}
