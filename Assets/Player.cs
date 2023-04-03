using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private PlayerInput _input;
    private Vector2 _direction;
    private Vector2 _rotate;
    private Vector2 _rotation;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();
    }

    private void Update()
    {
        _rotate = _input.Player.Look.ReadValue<Vector2>();
        _direction = _input.Player.Move.ReadValue<Vector2>();

        Look(_rotate);
        Move(_direction);
    }
    
    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude< 0.1)
            return;
        float scaleMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3 (_direction.x, 0, _direction.y);
        transform.position += move * scaleMoveSpeed;
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.1)
            return;

        float scaleRotateSpeed = _rotateSpeed * Time.deltaTime;
        _rotation.y += rotate.x * scaleRotateSpeed;
        _rotation.x = Mathf.Clamp(_rotation.x - rotate.y * scaleRotateSpeed, -90, 90);
        transform.localEulerAngles = _rotation;
    }
}
