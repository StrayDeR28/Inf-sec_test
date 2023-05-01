using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInput : MonoBehaviour
{
    public Button submit;
    public Toggle privacy;

    public bool isSugnip;

    public void Update()
    {
        if (!isSugnip)
        {
            if (Input.GetKeyDown(KeyCode.Return)) submit.onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && privacy.isOn) submit.onClick.Invoke();
    }
}
