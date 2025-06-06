using UnityEngine;

public class AgroRunInBehaviour : IEnemyBehaviour
{
    private readonly Enemy _enemy;
    private readonly Transform _player;

    public AgroRunInBehaviour(Enemy enemy, Transform player)
    {
        _enemy = enemy;
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("AgroRunIn: Вошли в состояние");
    }

    public void Update()
    {
        Vector3 directionToPlayer = _player.position - _enemy.transform.position;
        directionToPlayer.y = 0;

        Vector3 moveDirection = directionToPlayer.normalized;

        _enemy.ProcessMoveTo(moveDirection);
        _enemy.ProcessRotateTo(moveDirection);
    }

    public void Exit()
    {
        Debug.Log("AgroRunIn: Вышли из состояния");
    }
}
