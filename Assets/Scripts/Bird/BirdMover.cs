using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _mixAngle;
    [SerializeField] private float _rotationSpeed;

    public UnityAction WingClap;

    private Vector3 _starPosition;
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private float _maxHeight;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Bird.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxHeight = _camera.ViewportToWorldPoint(new Vector2(0, 1)).y;
        _starPosition = transform.position;
    }

    private void Update()
    {
        Rotate();
    }

    private void Jump()
    {
        if (transform.position.y < _maxHeight)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }

        WingClap?.Invoke();

        transform.localEulerAngles = new Vector3(0, 0, _maxAngle);
    }

    private void Rotate()
    {
        float rotation = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, _mixAngle, _rotationSpeed);
        transform.localEulerAngles = new Vector3(0, 0, rotation);
    }
}