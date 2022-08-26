public class HomeButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        LevelManager.Instance.LoadMenu();
    }
}
