using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class E1M4Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool rightElement;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            var oldElementTransform = transform.GetChild(0);//смена строк
            oldElementTransform.SetParent(eventData.pointerDrag.GetComponent<E1M4Drag>().GetTransform());
            oldElementTransform.localPosition = Vector3.zero;

            var newElementTransform = eventData.pointerDrag.transform;
            newElementTransform.SetParent(transform);
            newElementTransform.localPosition = Vector3.zero;
        }

        Color color = gameObject.GetComponent<Image>().color;
        color.a = 1f;
        gameObject.GetComponent<Image>().color = color;
    }
}
