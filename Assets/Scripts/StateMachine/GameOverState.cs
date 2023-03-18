using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameOverState : BaseState
{
    private UIMessage _uiMessage;

    public GameOverState(Bird bird, PipeGenerator pipeGenerator, IGameStateSwitcher gameStateSwitcher,List<UIMessage> uiMessages):
        base(bird,pipeGenerator,gameStateSwitcher)
    {
        _uiMessage = uiMessages.First(m => m as GameOverMessage);
    }

    public override void Enter()
    {
        _uiMessage.Show();
        Time.timeScale = 0;
        BirdMover.WingClap += OnWingClap;
    }

    public override void Exit()
    {
        _uiMessage.Hide();
        Time.timeScale = 1;
        BirdMover.WingClap -= OnWingClap;
    }

    public void OnWingClap()
    {
        GameStateSwitcher.SwitchState();
    }
}