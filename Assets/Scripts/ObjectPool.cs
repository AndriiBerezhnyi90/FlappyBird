using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] protected float Capacity;

    protected List<GameObject> Objects = new List<GameObject>();

    public void Restart()
    {
        foreach (var item in Objects)
        {
            item.SetActive(false);
        }
    }

    protected void Initialize(GameObject gameObject,Transform container)
    {
        for (int i = 0; i < Capacity; i++)
        {
            GameObject created = Instantiate(gameObject, container);
            created.SetActive(false);
            Objects.Add(created);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = Objects.FirstOrDefault(g => g.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectOutOfViewPort()
    {
        Vector2 disablePoint = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in Objects)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
            }
        }
    }
}