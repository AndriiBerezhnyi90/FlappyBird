using System.Collections;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetSpeed;

    private Coroutine _moving;

    private void Start()
    {
        _moving = StartCoroutine(CameraMove());
    }

    private IEnumerator CameraMove()
    {
        while (transform.position.x < _bird.transform.position.x - _offsetX)
        {
            float currentPosition = Mathf.MoveTowards(transform.position.x, _bird.transform.position.x - _offsetX, _offsetSpeed);
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);

            yield return null;
        }

        StopCoroutine(_moving);
    }
}