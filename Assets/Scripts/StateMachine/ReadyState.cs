using System.Collections.Generic;
using System.Linq;

public sealed class ReadyState : BaseState
{
    private UIMessage _uiMessage;
    private ScoresInfo _scoresInfo;
    private List<CreatorMover> _creatorMovers;

    public ReadyState(Bird bird, PipeGenerator pipeGenerator, IGameStateSwitcher gameStateSwitcher, List<UIMessage> uiMessages, 
                      ScoresInfo scoresInfo,List<CreatorMover> creatorMovers) :
    base(bird, pipeGenerator, gameStateSwitcher)
    {
        _uiMessage = uiMessages.First(p => p as ReadyMessage);
        _scoresInfo = scoresInfo;
        _creatorMovers = creatorMovers;
    }

    public override void Enter()
    {
        BirdMover.WingClap += OnWingClap;

        _uiMessage.Show();
        Bird.Restart();

        PipeGenerator.gameObject.SetActive(false);
        PipeGenerator.Restart();

        foreach (var creatorMover in _creatorMovers)
        {
            creatorMover.Restart();
        }

        _scoresInfo.SetAmount(0);
    }

    public override void Exit()
    {
        _uiMessage.Hide();
        PipeGenerator.gameObject.SetActive(true);
        BirdMover.WingClap -= OnWingClap;
    }

    private void OnWingClap()
    {
        GameStateSwitcher.SwitchState();
    }
}