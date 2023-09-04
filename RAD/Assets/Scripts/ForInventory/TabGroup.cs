using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public List<GameObject> invPages;

    public Color32 idleColor = new(255, 255, 255, 255);
    public Color32 activeColor = new(222, 180, 0, 255);
    
    public void AddToList(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        ResetTabs();
        button.currColor.color = activeColor;

        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < invPages.Count; i++)
        {
            if (i == index)
            {
                invPages[i].SetActive(true);
            }
            else
            {
                invPages[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            button.currColor.color = idleColor;
        }
    }
}