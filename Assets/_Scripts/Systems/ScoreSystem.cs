using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : Singleton<ScoreSystem>
{
    [SerializeField] private TMP_Text _levelInfoLabel;
    [SerializeField] private TMP_Text _availableBallsLabel;
    [SerializeField] private TMP_Text _neededBallslabel;

    private Level _level;

    private int _availableBalls;
    private int _scoredBalls;

    private bool _levelComplete = false;

    public void Start()
    {
        _level = ResourceSystem.Instance.GetLevel(GameManager.Instance.CurrentLevelNum);
        _levelInfoLabel.text = _level.levelName;
        _availableBalls = _level.ballsAvailable;
        UpdateScore();
    }

    private void Update()
    {
        if (CheckIfGameLost()) LevelManager.Instance.LoadLevel(
            GameManager.Instance.CurrentLevelNum); 
    }

    private void UpdateScore()
    {
        _availableBallsLabel.text = _availableBalls.ToString() + "/" 
            + _level.ballsAvailable.ToString();
        _neededBallslabel.text = _scoredBalls.ToString() + "/" + _level.ballsNeeded;
    }

    private bool CheckIfGameLost()
    {
        if (GameManager.Instance.State != GameState.LevelAction ||
            _levelComplete ||
            _availableBalls != 0) return false;

        if (GameObject.FindWithTag(Cannonball.ActiveCannonballTag) is not null) return false;

        return true;
    }
    
    public void AddOneScored()
    {
        if (_levelComplete) return;

        _scoredBalls++;
        UpdateScore();

        if (_scoredBalls == _level.ballsNeeded)
        {
            _levelComplete = true;
            GameManager.Instance.UpdateGameState(GameState.Victory);
        }
    }

    public void SubstractOneAvailable()
    {
        _availableBalls--;
        UpdateScore();
    } 
}
