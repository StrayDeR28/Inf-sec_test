using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class E7M1Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private int pieceNumber;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            if (eventData.pointerDrag.GetComponent<E7M1Drag>() && eventData.pointerDrag.GetComponent<E7M1Drag>().GetPieceNumber() == pieceNumber)
            {
                eventData.pointerDrag.GetComponent<E7M1Drag>().SetRightPositionFlag(true);
            }
        }
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;
    }
}
