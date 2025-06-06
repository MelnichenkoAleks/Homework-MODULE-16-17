using UnityEngine;

public class IdleStayBehaviour : IEnemyBehaviour
{
    public void Enter()
    {
        Debug.Log("IdleStay: ����� � ���������");
    }

    public void Update()
    {
        Debug.Log("IdleStay: ���������� (� ������ ������ ������ �� ������)");
    }

    public void Exit()
    {
        Debug.Log("IdleStay: ����� �� ���������");
    }
}
