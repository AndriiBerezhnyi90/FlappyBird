using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class BirdCollitionHandler : MonoBehaviour
{
    private int _scores;

    public UnityAction<int> CheckPoint;
    public UnityAction Dead;

    public void ResetScores()
    {
        _scores = 0;
        CheckPoint?.Invoke(_scores);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CheckPoint>())
            CheckPoint?.Invoke(++_scores);
        else if (collision.GetComponent<Obstacle>())
            Dead?.Invoke();
    }
}