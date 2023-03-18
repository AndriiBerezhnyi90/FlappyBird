public class FlyState : BaseState
{
    private BirdCollitionHandler _birdCollitionHandler;
    private ScoresInfo _scoresInfo;

    public FlyState(Bird bird, PipeGenerator pipeGenerator, IGameStateSwitcher gameStateSwitcher,ScoresInfo scoresInfo) :
        base(bird, pipeGenerator, gameStateSwitcher)
    {
        _birdCollitionHandler = bird.GetComponent<BirdCollitionHandler>();
        _scoresInfo = scoresInfo;
    }

    public override void Enter()
    {
        Bird.Release();
        _birdCollitionHandler.Dead += OnDead;
        _birdCollitionHandler.CheckPoint += OnCheckPoint;
        _birdCollitionHandler.ResetScores();
    }

    public override void Exit()
    {
        Bird.Freeze();
        _birdCollitionHandler.Dead -= OnDead;
        _birdCollitionHandler.CheckPoint -= OnCheckPoint;
    }

    private void OnDead()
    {
        GameStateSwitcher.SwitchState();
    }

    private void OnCheckPoint(int value)
    {
        _scoresInfo.SetAmount(value);
    }
}