using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE5M3 : MonoBehaviour
{
    [SerializeField] private List<GameObject> blocks;
    public void CheckParts()
    {
        bool checkCondition = false;
        foreach (GameObject item in blocks)
        {
            checkCondition = item.GetComponent<E5M3Drag>().GetRightPositionFlag();
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
