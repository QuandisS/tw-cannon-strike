public class HomeButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        MenuManager.Instance.LoadMenu();
    }
}
