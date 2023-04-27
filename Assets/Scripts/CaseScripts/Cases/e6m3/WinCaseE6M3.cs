using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE6M3 : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToScale;
    public void CheckParts()
    {
        bool checkCondition = false;
        foreach (GameObject item in objectsToScale)
        {
            checkCondition = item.GetComponent<SendTransformToScale>().GetRightScaleFlag();
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
