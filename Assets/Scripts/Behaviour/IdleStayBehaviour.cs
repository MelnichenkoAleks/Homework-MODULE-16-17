using UnityEngine;

public class IdleStayBehaviour : IEnemyBehaviour
{
    public void Enter()
    {
        Debug.Log("IdleStay: Вошли в состояние");
    }

    public void Update()
    {
        Debug.Log("IdleStay: Обновление (в данном случае ничего не делаем)");
    }

    public void Exit()
    {
        Debug.Log("IdleStay: Вышли из состояния");
    }
}
