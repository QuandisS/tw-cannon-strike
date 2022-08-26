using UnityEngine;

public class LevelLoadButton : ButtonBase
{
    [Range(1, 3)]
    [SerializeField]
    private int _levelNum = 1;

    protected override void OnButtonClick()
    {
        LevelManager.Instance.LoadLevel(_levelNum);
    }
}
