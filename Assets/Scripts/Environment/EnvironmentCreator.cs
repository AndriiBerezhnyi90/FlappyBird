using UnityEngine;

public abstract class EnvironmentCreator : MonoBehaviour
{
    [SerializeField] private Environment _template;
    [SerializeField] private Transform _container;
    [SerializeField] private float _amount;
    [SerializeField] private float _distanceBetweenTemplates;

    public float DistanceBetweenTemplates => _distanceBetweenTemplates;

    private void Awake()
    {
        CreateTemplates();
    }

    private void CreateTemplates()
    {
        for (int i = 0; i < _amount; i++)
        {
            var temp = Instantiate(_template.gameObject, _container);
            temp.transform.position = new Vector3(i * _distanceBetweenTemplates, transform.position.y);
        }
    }
}