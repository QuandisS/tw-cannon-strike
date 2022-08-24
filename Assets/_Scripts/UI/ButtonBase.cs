using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

[RequireComponent(typeof(Image))]
public class ButtonBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img;

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
        OnButtonClick();
        _img.color = Color.white;
    }

    protected virtual void OnButtonClick() {}
}
