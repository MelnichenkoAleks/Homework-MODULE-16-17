using UnityEngine;

public class AgroRunOutBehaviour : IEnemyBehaviour
{
    private readonly Enemy _enemy;
    private readonly Transform _player;

    public AgroRunOutBehaviour(Enemy enemy, Transform player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("AgroRunOut: Вошли в состояние");
    }

    public void Update()
    {
        Vector3 directionAway = _enemy.transform.position - _player.position;
        directionAway.y = 0f;

        Vector3 moveDirection = directionAway.normalized;

        _enemy.ProcessMoveTo(moveDirection);
        _enemy.ProcessRotateTo(moveDirection);
    }

    public void Exit()
    {
        Debug.Log("AgroRunOut: Вышли из состояния");
    }
}