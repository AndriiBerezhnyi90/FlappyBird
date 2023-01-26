using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerInput = new PlayerInput();   
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput.Bird.Jump.performed += ctx => Jump();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_moveSpeed, _rigidbody.velocity.y);    
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_moveSpeed, 0);
        _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}