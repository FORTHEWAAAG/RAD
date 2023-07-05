using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseInvTabs : MonoBehaviour
{
    public static bool PlayerTab = true;
    public static bool ItemsTab = false;
    public static bool CraftTab = false;
    public static bool QuestsTab = false;


    public Color activeColor = new Color(255, 255, 0, 0);   // 255, 255, 0, 0
    public Color disabledColor = new Color(255, 255, 255, 255); // 255, 255, 255, 255


    public void OpenPlayerTab()
    {
        if (PlayerTab == false)
        {
            PlayerTab = true;

            ItemsTab = false;
            CraftTab = false;
            QuestsTab = false;

            SetActive();
        }
    }

    public void OpenItemsTab()
    {
        if (ItemsTab == false)
        {
            ItemsTab = true;

            PlayerTab = false;
            CraftTab = false;
            QuestsTab = false;

            SetActive();
        }
    }

    public void OpenCraftTab()
    {
        if (CraftTab == false)
        {
            CraftTab = true;

            PlayerTab = false;
            ItemsTab = false;
            QuestsTab = false;

            SetActive();
        }
    }

    public void OpenQuestsTab()
    {
        if (QuestsTab == false)
        {
            QuestsTab = true;

            PlayerTab = false;
            ItemsTab = false;
            CraftTab = false;

            SetActive();
        }
    }

    public void SetActive()
    {
        var setNewColor = GetComponent<Button> ().colors;
        setNewColor.normalColor = activeColor;
        setNewColor.highlightedColor = activeColor;
        setNewColor.pressedColor = activeColor;
        setNewColor.selectedColor = activeColor;
        GetComponent<Button> ().colors = setNewColor;
    }

    public void SetDisabled()
    {
        var setNewColor = GetComponent<Button> ().colors;
        setNewColor.normalColor = disabledColor;
        setNewColor.highlightedColor = disabledColor;
        setNewColor.pressedColor = disabledColor;
        setNewColor.selectedColor = disabledColor;
        GetComponent<Button> ().colors = setNewColor;
    }
}
