using UnityEngine;

public class BoySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBoy;
    [SerializeField] private Transform _spawnPointBoy;

    private void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (_prefabBoy == null || _spawnPointBoy == null)
            return;

        Instantiate(_prefabBoy, _spawnPointBoy.position, _spawnPointBoy.rotation);
    }
}
