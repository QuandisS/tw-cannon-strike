using UnityEngine.EventSystems;
using UnityEngine;

public class SoundToggleButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        AudioSystem.Instance.ToggleMute();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
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
