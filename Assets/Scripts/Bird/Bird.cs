using UnityEngine;

[RequireComponent(typeof(BirdMover),typeof(Animator),typeof(BirdCollitionHandler))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private Animator _animator;

    private void OnEnable()
    {
        BirdMover.WingClap += OnWingClap;
    }

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        BirdMover.WingClap += OnWingClap;
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        _birdMover.Restart();
        _animator.SetTrigger(BirdAnimations.Parameters.Ready);
    }

    public void Release()
    {
        _birdMover.ReleasePosition();
        _animator.Play(BirdAnimations.Parameters.WingClap);
    }

    public void Freeze()
    {
        _birdMover.FreezePosition();
        _animator.StopPlayback();
    }

    private void OnWingClap()
    {
        _animator.SetTrigger(BirdAnimations.Parameters.WingClap);
    }
}

public static class BirdAnimations
{
    public static class Parameters
    {
        public const string WingClap = nameof(WingClap);
        public const string Ready = nameof(Ready);
    }
}