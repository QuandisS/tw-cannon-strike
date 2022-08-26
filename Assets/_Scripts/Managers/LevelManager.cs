using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private const string LevelPrefix = "Level ";
    private const string Menu = "Menu";

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    public void LoadLevel(int levelNum)
    {
        if (levelNum > ResourceSystem.Instance.LevelCount)
        {
            LoadMenu();
            return;
        }

        GameManager.Instance.CurrentLevelNum = levelNum;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(LevelPrefix + levelNum.ToString());
        asyncLoad.completed += OnLevelLoaded;
    }

    private void OnLevelLoaded(AsyncOperation ao)
    {
        GameManager.Instance.UpdateGameState(GameState.LevelAction);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Menu);
        GameManager.Instance.UpdateGameState(GameState.Menu);
    }

    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Victory:
                LoadNextLevel();               
                break;
            
            case GameState.Lose:
                break;

            default:
                break;
        }
    }

    private void LoadNextLevel() => LoadLevel(GameManager.Instance.CurrentLevelNum + 1);
}
