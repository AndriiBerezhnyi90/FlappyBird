using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour, IGameStateSwitcher
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private List<UIMessage> _uiMessages;
    [SerializeField] private ScoresInfo _scoresInfo;
    [SerializeField] private List<CreatorMover> _creatorMovers;

    private BaseState _currentState;
    private Queue<BaseState> _allStates;

    private void Awake()
    {
        _allStates = new Queue<BaseState>();

        _allStates.Enqueue(new ReadyState(_bird, _pipeGenerator, this, _uiMessages, _scoresInfo, _creatorMovers));
        _allStates.Enqueue(new FlyState(_bird, _pipeGenerator, this, _scoresInfo));
        _allStates.Enqueue(new GameOverState(_bird, _pipeGenerator, this, _uiMessages));

        _currentState = _allStates.Dequeue();
        _currentState.Enter();
    }

    public void SwitchState()
    {
        _currentState.Exit();
        _allStates.Enqueue(_currentState);

        _currentState = _allStates.Dequeue();
        _currentState.Enter();
    }
}