using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListViewDrag : MonoBehaviour, IPointerDownHandler, IDragHandler,  IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private int elementNumber;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    [SerializeField] private GameObject oldPositionHolder;

    Transform parentAfterDrag;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 0.6f;
        gameObject.GetComponent<Image>().color = color;
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (rectTransform.anchoredPosition.x != 133)
        {
            rectTransform.anchoredPosition = new Vector2(133, rectTransform.anchoredPosition.y);
        }       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //костыль
        if(rectTransform.anchoredPosition.y >=168 || rectTransform.anchoredPosition.y <= -234)
        {
            rectTransform.anchoredPosition = new Vector2(oldPositionHolder.GetComponent<OldPositionHolder>().GetOldPosition().x, oldPositionHolder.GetComponent<OldPositionHolder>().GetOldPosition().y);
        }
        if( Mathf.Abs(oldPositionHolder.GetComponent<OldPositionHolder>().GetOldPosition().y - rectTransform.anchoredPosition.y) <= 35f)
        {
            print("dfs");
            rectTransform.anchoredPosition = new Vector2 (oldPositionHolder.GetComponent<OldPositionHolder>().GetOldPosition().x, oldPositionHolder.GetComponent<OldPositionHolder>().GetOldPosition().y);
        }
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;
        gameObject.GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        oldPositionHolder.GetComponent<OldPositionHolder>().SetOldPosition(rectTransform.anchoredPosition);
    }

    public void OnDrop(PointerEventData eventData)
    {

    }
    public int GetElementNumber()
    {
        return elementNumber;
    }
}