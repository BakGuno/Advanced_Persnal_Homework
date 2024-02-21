using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletoneBase<UIManager>
{

    private static UIManager _singleton = new UIManager();
    public static UIManager Get() { return _singleton; }
    public static bool Has() { return _singleton != null; }

    private List<UIPopup> popups = new List<UIPopup>();

    public UIPopup ShowPopup(string popupname,Transform parents)
    {
        var obj = Resources.Load("Prefabs/UI/" + popupname, typeof(GameObject)) as GameObject;
        if (!obj)
        {
            Debug.LogWarning(string.Format("Failed to ShowPopup({0})",popupname));
            return null;
        }
        return ShowPopupWithPrefab(obj, popupname,parents);
    }

    public UIPopup ShowPopupWithPrefab(GameObject prefab, string popupName,Transform parents)
    {
        var obj = Instantiate(prefab,parents);
        return ShowPopup(obj, popupName);
    }

    public UIPopup ShowPopup(GameObject obj, string popupname)
    {
        var popup = obj.GetComponent<UIPopup>();
        popups.Insert(0, popup);

        obj.SetActive(true);
        return popup;
    }
}