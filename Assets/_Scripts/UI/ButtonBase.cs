using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected Image _img;

    private void OnValidate() 
    {
        _img = gameObject.GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.color = Color.grey;        
    }    

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.color = Color.white;
        OnButtonClick();
    }

    protected virtual void OnButtonClick() {}
}
