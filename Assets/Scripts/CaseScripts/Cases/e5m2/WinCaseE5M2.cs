using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE5M2 : MonoBehaviour
{
    [SerializeField] private List<GameObject> elementsPosition;
    public void CheckParts()
    {
        bool checkCondition = false;
        foreach (GameObject item in elementsPosition)
        {
            checkCondition = item.GetComponent<LIstViewDrop>().IsRightElement();
            if (checkCondition == false)
            {
                return;
            }
        }
        if (checkCondition == true)
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
