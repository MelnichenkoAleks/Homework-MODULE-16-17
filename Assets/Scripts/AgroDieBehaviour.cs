using UnityEngine;

public class AgroDieBehaviour : IEnemyAggroBehaviour
{
    public void EnemyAggroBehaviour(Enemy enemy, Transform player)
    {
        Object.Destroy(enemy.gameObject);
    }
}
