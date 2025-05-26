using UnityEngine;

public class AggroRunOutBehaviour : IEnemyAggroBehaviour
{
    public void EnemyAggroBehaviour(Enemy enemy, Transform player)
    {
        Vector3 directionAwayFromPlayer = enemy.transform.position - player.position;
        directionAwayFromPlayer.y = 0; 

        Vector3 moveDirection = directionAwayFromPlayer.normalized;

        enemy.ProcessMoveTo(moveDirection);

        enemy.ProcessRotateTo(moveDirection);
    }
}