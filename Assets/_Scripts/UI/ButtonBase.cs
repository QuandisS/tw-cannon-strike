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

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _img.color = Color.grey;        
    }    

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        OnButtonClick();
        _img.color = Color.white;
    }

    protected virtual void OnButtonClick() {}
}
