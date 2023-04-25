using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE7M1 : MonoBehaviour
{
    [SerializeField] private List<GameObject> blocks;
    public void CheckParts()
    {
        bool checkCondition = false;
        foreach (GameObject item in blocks)
        {
            checkCondition = item.GetComponent<E7M1Drag>().GetRightPositionFlag();
            if (checkCondition == false)
            {
                return;
            }
        }
        gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
    }
}

