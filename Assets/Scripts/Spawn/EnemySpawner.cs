using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnDistribution _spawnController;
    [SerializeField] private Transform _player;

    private IEnemyBehaviour CreateIdleBehaviour(SpawnPoint spawnPoint, Enemy enemy)
    {
        return spawnPoint.IdleBehaviourType switch
        {
            IdleBehaviourTypes.Stay => new IdleStayBehaviour(),
            IdleBehaviourTypes.Patrol => new IdlePatrolBehaviour(enemy, spawnPoint.patrolPoints),
            IdleBehaviourTypes.Random => new IdleRandomBehaviour(enemy),
            _ => new IdleStayBehaviour(),
        };
    }

    private IEnemyBehaviour CreateAggroBehaviour(AggroBehaviourTypes type, Enemy enemy)
    {
        return type switch
        {
            AggroBehaviourTypes.RunOut => new AgroRunOutBehaviour(enemy, _player),
            AggroBehaviourTypes.RunIn => new AgroRunInBehaviour(enemy, _player),
            AggroBehaviourTypes.Die => new AgroDieBehaviour(enemy),
            _ => new AgroRunOutBehaviour(enemy, _player),
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

                    var idleBehaviour = CreateIdleBehaviour(spawnPoint, enemy);
                    var aggroBehaviour = CreateAggroBehaviour(spawnPoint.AggroBehaviourType, enemy);

                    enemy.SetBehaviours(idleBehaviour, aggroBehaviour, _player);
                }
            }
        }
        else
        {
            Debug.LogError("The number of spawnPoints and enemyPrefabs do not match in SpawnController.");
        }
    }
}
