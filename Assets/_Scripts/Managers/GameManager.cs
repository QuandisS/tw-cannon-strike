using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    private GameState _state = GameState.Menu;

    [HideInInspector]
    public int CurrentLevelNum;

    public GameState State => _state;

    public event Action<GameState> OnGameStateChanged;

    public void UpdateGameState(GameState newState)
    {
        _state = newState;
        OnGameStateChanged.Invoke(_state);
    }
}

public enum GameState
{
    Menu,
    LevelAction,
    Lose,
    Victory
}
