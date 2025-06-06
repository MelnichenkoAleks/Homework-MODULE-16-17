using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    public void ProcessRotateTo(Vector3 direction)
    {
        Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

        Quaternion lookRotation = Quaternion.LookRotation(xzDirection);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
