using UnityEngine;

[RequireComponent(typeof(PipePool))]
public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnRate;

    private PipePool _pipePool;
    private Vector2 _disablePoint => Camera.main.ViewportToWorldPoint(new Vector2(0, 0.5f));
    private float _elapsedTime = 0;

    private void Start()
    {
        _pipePool = GetComponent<PipePool>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _spawnRate)
        {
        }
    }

    private void SpawnPipe()
    {

    }
}