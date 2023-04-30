using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE1M4 : MonoBehaviour
{   
    [SerializeField] private GameObject grid;
    [SerializeField] private List<GameObject> elementsPosition;
    public void CheckParts()
    {
        var gridTransform = grid.GetComponent<Transform>();
        bool checkCondition = false;
        for (int i = 0; i < gridTransform.childCount; i++) 
        {
            if (gridTransform.GetChild(i).GetChild(0) != elementsPosition[i].transform)
            {
                checkCondition = false;
                print(checkCondition);
                break;
            }
            else
            {
                checkCondition = true;
                print(checkCondition);
            }
        }
        if (checkCondition == true)
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
