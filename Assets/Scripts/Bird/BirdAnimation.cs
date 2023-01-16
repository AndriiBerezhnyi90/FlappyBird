using UnityEngine;

[RequireComponent(typeof(BirdMover),typeof(Animator))]
public class BirdAnimation : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        GetComponent<BirdMover>().WingClap += OnWingClap;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        GetComponent<BirdMover>().WingClap -= OnWingClap;
    }

    private void OnWingClap()
    {
        _animator.SetTrigger(Params.WingClap);
    }

    private static class Params
    {
        public const string WingClap = nameof(WingClap);
    }
}