using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabGroup tabGroup;

    public Image currColor;

    public void Start()
    {
        currColor = GetComponent<Image>();
        tabGroup.AddToList(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }
}
