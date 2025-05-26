using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Transform _playerTarget;

    private float _speed = 3.5f;
    private float _rotationSpeed = 800f;
    private float _agroDistance = 5f;
    private float _minDistanceToPlayer = 1f;

    private bool _isAggro = false;

    private IEnemyIdleBehaviour _enemyIdleBehaviour;
    private IEnemyAggroBehaviour _enemyAggroBehaviour;

    public float Speed => _speed;
    public Transform PlayerTarget => _playerTarget;

    private void Start()
    {   
        FindPlayer(_player);
    }

    public void SetBehaviours(IEnemyIdleBehaviour idle, IEnemyAggroBehaviour aggro)
    {
        _enemyIdleBehaviour = idle;
        _enemyAggroBehaviour = aggro;
    }

    private void Update()
    {
        if (_playerTarget == null)
        {
            Debug.LogWarning("Player target is null!");
            return;
        }

        float distance = Vector3.Distance(transform.position, _playerTarget.position);
        bool isNowAggro = distance <= _agroDistance;

        Debug.Log($"Distance to player: {distance:F2}. Aggro range: {_agroDistance}. Is aggro now: {isNowAggro}");

        if (isNowAggro != _isAggro)
        {
            _isAggro = isNowAggro;
            Debug.Log($"Aggro state changed to: {_isAggro}");
        }

        if (_isAggro)
        {
            Debug.Log("Enemy is aggroed, executing aggro behaviour");

            if (distance > _minDistanceToPlayer)
            {
                _enemyAggroBehaviour?.EnemyAggroBehaviour(this, _playerTarget);
            }
            else
            {
                Debug.Log("Enemy is close enough to player, stopping movement");
            }
        }
        else
        {
            Debug.Log("Enemy is idle, executing idle behaviour");
            _enemyIdleBehaviour?.EnemyIdleBehaviour(this);
        }
    }

    private void FindPlayer(GameObject owner)
    {
        MovePlayerController playerController = FindObjectOfType<MovePlayerController>();
        if (playerController != null)
        {
            _playerTarget = playerController.transform;
            Debug.Log("Player target found and assigned");
        }
        else
        {
            Debug.LogError("Object with MovePlayerController not found in the scene");
        }
    }

    public void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    public void ProcessRotateTo(Vector3 direction)
    {
        Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

        Quaternion lookRotation = Quaternion.LookRotation(xzDirection);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
