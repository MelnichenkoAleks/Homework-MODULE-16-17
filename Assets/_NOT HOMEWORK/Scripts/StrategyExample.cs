using System.Collections.Generic;
using UnityEngine;

public class StrategyExample : MonoBehaviour
{
    [SerializeField] private Boy _boyPrefab;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Transform> _targets;

    private List<Boy> _spawnedBoys = new List<Boy>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Boy boy = CreateBoy();
            boy.Initialize(new HighestTargetSelector(), _targets);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Boy boy = CreateBoy();
            boy.Initialize(new LowerTatgetSelector(), _targets);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Boy boy = CreateBoy();
            boy.Initialize(new DistanceTargetSelector(boy.transform), _targets);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach(Boy boy in _spawnedBoys)
            {
                boy.SetTargetSelector(new HighestTargetSelector());
            }
        }
    }

    private Boy CreateBoy()
    {
        Boy boy = Instantiate(_boyPrefab, _spawnPoint.position, Quaternion.identity);
        _spawnedBoys.Add(boy);
        return boy;
    }
}
