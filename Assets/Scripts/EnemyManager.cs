using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SpawnDistribution _spawnController;

    private IEnemyIdleBehaviour CreateIdleBehaviour(SpawnPoint spawnPoint)
    {
        return spawnPoint.IdleBehaviourType switch
        {
            IdleBehaviourTypes.Stay => new IdleStayBehaviour(),
            IdleBehaviourTypes.Patrol => new IdlePatrolBehaviour(spawnPoint.patrolPoints),
            IdleBehaviourTypes.Random => new IdleRandomBehaviour(),
            _ => new IdleStayBehaviour(),
        };
    }

    private IEnemyAggroBehaviour CreateAggroBehaviour(AggroBehaviourTypes type)
    {
        return type switch
        {
            AggroBehaviourTypes.RunOut => new AggroRunOutBehaviour(),
            AggroBehaviourTypes.RunIn => new AgroRunInBehaviour(),
            AggroBehaviourTypes.Die => new AgroDieBehaviour(),
            _ => new AggroRunOutBehaviour(),
        };
    }

    private void Awake()
    {
        if (_spawnController.spawnPoints.Count == _spawnController.enemyPrefabs.Count)
        {
            for (int i = 0; i < _spawnController.spawnPoints.Count; i++)
            {
                SpawnPoint spawnPoint = _spawnController.spawnPoints[i];
                Enemy enemyPrefab = _spawnController.enemyPrefabs[i];

                if (spawnPoint != null && enemyPrefab != null && spawnPoint.IsEmpty)
                {
                    Enemy enemy = Instantiate(enemyPrefab, spawnPoint.Position, Quaternion.identity);
                    spawnPoint.Occupy(enemy);

                    IEnemyIdleBehaviour idleBehaviour = CreateIdleBehaviour(spawnPoint);
                    IEnemyAggroBehaviour aggroBehaviour = CreateAggroBehaviour(spawnPoint.AggroBehaviourType);

                    enemy.SetBehaviours(idleBehaviour, aggroBehaviour);
                }
            }
        }
        else
        {
            Debug.LogError("The number of spawnPoints and enemyPrefabs do not match in SpawnController.");
        }
    }
}
