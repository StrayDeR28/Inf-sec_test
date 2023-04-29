using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE6M4 : MonoBehaviour
{
    [SerializeField] private GameObject dishes;
    [SerializeField] private List<GameObject> dishesPosition;
    public void CheckDishesPosition()
    {
        var dishesTransform = dishes.GetComponent<Transform>();
        bool checkCondition = false;
        for (int i = 0; i < dishesTransform.childCount; i++)
        {
            if (dishesTransform.GetChild(i).GetChild(0) != dishesPosition[i].transform)
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