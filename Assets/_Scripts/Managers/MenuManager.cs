using UnityEngine.SceneManagement;

public class MenuManager : StaticInstance<MenuManager>
{
    private const string LevelPrefix = "Level ";

    public void LoadLevel(int levelNum)
    {
        SceneManager.LoadScene(LevelPrefix + levelNum.ToString());
    }
}
