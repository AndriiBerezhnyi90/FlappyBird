using UnityEngine;

public class PipePool : ObjectPool
{
    [SerializeField] private PipePair _template;

    private void Start()
    {
        Initialize(_template.gameObject,gameObject.transform);
    }

    public void SpawnObject(Vector2 position)
    {
        if(TryGetObject(out GameObject result))
        {
            result.SetActive(true);
            result.transform.position = position;
        }

        DisableObjectOutOfViewPort();
    }
}