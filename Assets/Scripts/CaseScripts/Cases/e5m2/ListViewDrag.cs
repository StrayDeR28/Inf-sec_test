using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListViewDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform currentTransform;
    private GameObject mainContent;
    private Vector3 currentPossition;

    private int totalChild;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int elementNumber;
    private void Awake()
    {
        mainContent = currentTransform.parent.gameObject;
        totalChild = mainContent.transform.childCount;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        currentPossition = currentTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentTransform.position += (Vector3)eventData.delta;
        //new Vector3(currentTransform.position.x, eventData.position.y, currentTransform.position.z);//а если всё от eventData?

        for (int i = 0; i < totalChild; i++)
        {
            if (i != currentTransform.GetSiblingIndex())
            {
                Transform otherTransform = mainContent.transform.GetChild(i);
                int distance = (int)Vector3.Distance(currentTransform.position,
                    otherTransform.position);
                if (distance <= 10)
                {
                    Vector3 otherTransformOldPosition = otherTransform.position;
                    otherTransform.position = new Vector3(otherTransform.position.x, currentPossition.y,
                        otherTransform.position.z);
                    currentTransform.position = new Vector3(currentTransform.position.x, otherTransformOldPosition.y,
                        currentTransform.position.z);
                    currentTransform.SetSiblingIndex(otherTransform.GetSiblingIndex());
                    currentPossition = currentTransform.position;
                }
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 0.6f;
        gameObject.GetComponent<Image>().color = color;
        //gameObject.GetComponent<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;
       // gameObject.GetComponent<Image>().raycastTarget = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        currentTransform.position = currentPossition;
    }
    public int GetElementNumber()
    {
        return elementNumber;
    }
}