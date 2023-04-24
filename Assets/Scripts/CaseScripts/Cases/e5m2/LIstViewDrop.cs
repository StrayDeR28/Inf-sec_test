using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LIstViewDrop : MonoBehaviour
{
    [SerializeField] private int elementNumber;
    [SerializeField] private bool rightElement;
    public void OnDrop(PointerEventData eventData)
    {
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
