using UnityEngine;
public class IdleRandomBehaviour : IEnemyBehaviour
{
    private readonly Enemy _enemy;

    private Vector3 _currentDirection = Vector3.zero;

    private float _changeDirectionTime = 1f;
    private float _timer = 0f;

    public IdleRandomBehaviour(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        _timer = _changeDirectionTime;
        ChooseNewDirection();
    }

    public void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            ChooseNewDirection();
            _timer = _changeDirectionTime;
        }

        _enemy.ProcessMoveTo(_currentDirection);
        _enemy.ProcessRotateTo(_currentDirection);
    }


    public void Exit()
    {
        _enemy.ProcessMoveTo(Vector3.zero);
    }

    private void ChooseNewDirection()
    {
        float angle = Random.Range(0f, 360f);
        _currentDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }
}
