using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Awake()
    {
        FindPlayer(_player);
    }

    private void FindPlayer(GameObject owner)
    {
        MoveController player = owner.GetComponent<MoveController>();
    }
}
