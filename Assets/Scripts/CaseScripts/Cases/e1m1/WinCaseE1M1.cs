using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE1M1 : MonoBehaviour
{
    [SerializeField] int count;

    public void SetCount()
    {
        count++;
        print(count);
    }

    public void CaseWin()
    {
        if (count == 20)
        {
            print("прошел");
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}