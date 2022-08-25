using UnityEngine;

public class SoundToggleButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        AudioSystem.Instance.ToggleMute();
        UpdateButtonColor();
    }

    private void Start() 
    {
        UpdateButtonColor();
    }

    private void UpdateButtonColor()
    {
        _img.color = AudioSystem.Instance.IsMuted ? Color.red : Color.green;
    }
}
