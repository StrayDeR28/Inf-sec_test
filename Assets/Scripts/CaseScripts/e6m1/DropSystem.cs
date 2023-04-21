using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSystem : MonoBehaviour, IDropHandler
{
    [SerializeField] private int pieceNumber;
    [SerializeField] private GameObject pieceCounter;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<DragSystem>().GetPieceNumber() == pieceNumber)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Destroy(eventData.pointerDrag.GetComponent("DragSystem"));
            pieceCounter.GetComponent<WinCaseE6M1>().SetPieceCounter();
        }
    }
}
