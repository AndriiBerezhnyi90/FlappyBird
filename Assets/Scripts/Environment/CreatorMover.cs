using UnityEngine;

[RequireComponent(typeof(EnvironmentCreator),typeof(BoxCollider2D))]
public class CreatorMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private EnvironmentCreator _generator;
    private BoxCollider2D _boxCollider2D;
    
    private Vector2 _startPostion;

    private void Awake()
    {
        _generator = GetComponent<EnvironmentCreator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
        _boxCollider2D.offset = new Vector2(_generator.DistanceBetweenTemplates, 0);
        _startPostion = transform.position;
    }

    private void Update()
    {
        transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
    }

    public void Restart()
    {
        transform.position = _startPostion;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DespawnPoint>())
        {
            Vector2 targetPosition = new Vector2(transform.position.x + _generator.DistanceBetweenTemplates, transform.position.y);
            transform.position = targetPosition;
        }
    }
}