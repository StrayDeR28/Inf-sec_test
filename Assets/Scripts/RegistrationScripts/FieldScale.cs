using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FieldScale : MonoBehaviour
{

    public void SizeUp()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(477f, 67f);
    }
    public void SizeDown()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(465f, 55f);
    }
}
