using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 10;

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }
}
