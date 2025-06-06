using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _rotationSpeed = 800f;
    [SerializeField] private float _agroDistance = 5f;

    private Transform _playerTarget;

    private IEnemyBehaviour _idleBehaviour;
    private IEnemyBehaviour _aggroBehaviour;
    private IEnemyBehaviour _currentBehaviour;

    private bool _isAggro;

    public float Speed => _speed;
    public Transform PlayerTarget => _playerTarget;

    private void Update()
    {
        if (_playerTarget == null)
        {
            Debug.LogWarning("Player target is null!");
            return;
        }

        float distance = Vector3.Distance(transform.position, _playerTarget.position);
        bool shouldBeAggro = distance <= _agroDistance;

        if (shouldBeAggro != _isAggro)
        {
            _isAggro = shouldBeAggro;
            SwitchBehaviour(_isAggro ? _aggroBehaviour : _idleBehaviour);
        }

        _currentBehaviour?.Update();
    }

    public void SetBehaviours(IEnemyBehaviour idle, IEnemyBehaviour aggro, Transform playerTarget)
    {
        _idleBehaviour = idle;
        _aggroBehaviour = aggro;
        _playerTarget = playerTarget;

        _currentBehaviour = _idleBehaviour;
        _currentBehaviour?.Enter();
    }

    private void SwitchBehaviour(IEnemyBehaviour newBehaviour)
    {
        _currentBehaviour?.Exit();
        _currentBehaviour = newBehaviour;
        _currentBehaviour?.Enter();
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
