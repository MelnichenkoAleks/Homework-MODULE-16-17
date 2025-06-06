using UnityEngine;

public class AgroDieBehaviour : IEnemyBehaviour
{
    private readonly Enemy _enemy;

    public AgroDieBehaviour(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("AgroDie: ����� � ���������");
    }

    public void Update()
    {
        Object.Destroy(_enemy.gameObject);
    }

    public void Exit()
    {
        Debug.Log("AgroDie: ����� �� ���������");
    }
}
