using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Utils
{
    public static bool IsPointerOverUi()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else
        {
            var pe = new PointerEventData(EventSystem.current) {position = Input.mousePosition};
            var hits = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pe, hits);
            return hits.Count > 0;
        }
    }
}