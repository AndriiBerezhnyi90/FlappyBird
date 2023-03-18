using UnityEngine;

[RequireComponent(typeof(PipePool))]
public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _offsetY;

    private PipePool _pipePool;
    private float _elapsedTime = 0;

    private void Awake()
    {
        _pipePool = GetComponent<PipePool>();
    }

    private void OnEnable()
    {
        _elapsedTime = _spawnRate;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _spawnRate)
        {
            Vector2 spawnPosition = new Vector2(_spawnPoint.position.x, Random.Range(-_offsetY, _offsetY));
            _pipePool.SpawnObject(spawnPosition);
            _elapsedTime = 0;
        }
    }

    public void Restart()
    {
        _pipePool.Restart();
    }
}