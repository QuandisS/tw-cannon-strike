using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    private const string LevelPrefix = "Level ";
    private const string Menu = "Menu";

    public void LoadLevel(int levelNum)
    {
        SceneManager.LoadScene(LevelPrefix + levelNum.ToString());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Menu);
    }
}
