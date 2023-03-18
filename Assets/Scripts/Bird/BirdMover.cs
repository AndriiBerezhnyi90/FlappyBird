using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxRotate;
    [SerializeField] private float _minRotate;
    [SerializeField] private float _rotateSpeed;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition;

    public static UnityAction WingClap;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput.Bird.Jump.performed += ctx => Jump();
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_moveSpeed, _rigidbody.velocity.y);
        Rotate();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void Restart()
    {
        transform.position = _startPosition;
        transform.localEulerAngles = Vector3.zero;
        FreezePosition();
    }

    public void FreezePosition()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void ReleasePosition()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    private void Jump()
    {
        if (_rigidbody.constraints != RigidbodyConstraints2D.FreezeAll)
        {
            _rigidbody.velocity = new Vector2(_moveSpeed, 0);
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            transform.localEulerAngles = new Vector3(0, 0, _maxRotate);
        }

        WingClap?.Invoke();
    }

    private void Rotate()
    {
        if (_rigidbody.constraints != RigidbodyConstraints2D.FreezeAll)
        {
            float rotate = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, _minRotate, _rotateSpeed * Time.deltaTime);
            _rigidbody.rotation = rotate;
        }
    }
}