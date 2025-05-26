using UnityEngine;

public class AgroRunInBehaviour : IEnemyAggroBehaviour
{
    public void EnemyAggroBehaviour(Enemy enemy, Transform player)
    {
        Vector3 directionToPlayer = player.position - enemy.transform.position;
        directionToPlayer.y = 0; 

        Vector3 moveDirection = directionToPlayer.normalized;

        enemy.ProcessMoveTo(moveDirection);

        enemy.ProcessRotateTo(moveDirection);
    }
}
