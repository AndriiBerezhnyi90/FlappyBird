public abstract class BaseState
{
    protected readonly Bird Bird;
    protected readonly PipeGenerator PipeGenerator;
    protected readonly IGameStateSwitcher GameStateSwitcher;

    public BaseState(Bird bird, PipeGenerator pipeGenerator, IGameStateSwitcher gameStateSwitcher)
    {
        Bird = bird;
        PipeGenerator = pipeGenerator;
        GameStateSwitcher = gameStateSwitcher;
    }

    public abstract void Enter();

    public abstract void Exit();
}