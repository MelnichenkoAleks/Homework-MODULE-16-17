using UnityEngine;
public class IdleRandomBehaviour : IEnemyIdleBehaviour
{
    private Vector3 _currentDirection = Vector3.zero;
    private float _changeDirectionTime = 1f;
    private float _timer = 0f;

    public void EnemyIdleBehaviour(Enemy enemy)
    {
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                float angle = Random.Range(0f, 360f);
                _currentDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;

                _timer = _changeDirectionTime;
            }

            enemy.ProcessMoveTo(_currentDirection);
            enemy.ProcessRotateTo(_currentDirection);
        }
    }
}
