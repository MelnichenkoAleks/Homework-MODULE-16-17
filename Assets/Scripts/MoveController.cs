using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Mover _mover;

    private Rotator _rotator;

    private string _horizontalAxisName = "Horizontal";
    private string _verticalAxisName = "Vertical";

    private float _deadZone = 0.1f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(_horizontalAxisName), 0, Input.GetAxisRaw(_verticalAxisName));

        if (input.magnitude <= _deadZone)
            return;

        Vector3 normalizedInput = input.normalized;

        _mover.ProcessMoveTo(normalizedInput);

        _rotator.ProcessRotateTo(normalizedInput);
    }
}
