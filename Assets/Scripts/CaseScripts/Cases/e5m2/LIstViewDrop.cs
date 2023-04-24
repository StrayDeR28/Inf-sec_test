using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LIstViewDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private int elementNumber;
    [SerializeField] private bool rightElement;
    [SerializeField] private GameObject oldPositionHolder;
    public void OnDrop(PointerEventData eventData)
    {
        
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;
        GetComponent<RectTransform>().anchoredPosition = oldPositionHolder.GetComponent<OldPositionHolder>().GetOldPosition();
        if (eventData.pointerDrag.GetComponent<ListViewDrag>().GetElementNumber() == elementNumber)
        {
            rightElement = true;
        }
        else
        {
            rightElement = false;
        }
    }
    public bool IsRightElement()
    {
        return rightElement;
    }
}
