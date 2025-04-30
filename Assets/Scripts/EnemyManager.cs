using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SpawnDistribution _spawnController;

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
                }
            }
        }
        else
        {
            Debug.LogError("Количество spawnPoints и enemyPrefabs не совпадает в SpawnController.");
        }

    }
}
