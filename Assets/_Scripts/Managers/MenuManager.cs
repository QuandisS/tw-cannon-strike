using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class MenuManager : Singleton<MenuManager>
{
    private const string LevelPrefix = "Level ";
    private const string Menu = "Menu";

    public void LoadLevel(int levelNum)
    {
        GameManager.Instance.CurrentLevelNum = levelNum;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(LevelPrefix + levelNum.ToString());
        asyncLoad.completed += OnLevelLoaded;
    }

    private void OnLevelLoaded(AsyncOperation ao)
    {
        GameManager.Instance.UpdateGameState(GameState.LevelLoaded);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Menu);
        GameManager.Instance.UpdateGameState(GameState.Menu);
    }
}
