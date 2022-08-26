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

        switch(_state)
        {
            case GameState.Menu:
                break;

            case GameState.LevelLoaded:
                break;
                        
            case GameState.Lose:
                break;
            
            case GameState.Victory:
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(_state), _state, null);
        }

        OnGameStateChanged.Invoke(_state);

    }
}

public enum GameState
{
    Menu,
    LevelLoaded,
    Lose,
    Victory
}
