using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE2M1 : MonoBehaviour
{
    [SerializeField] int count;

    public void SetCount()
    {
        count++;
        print(count);
    }

    public void CaseWin()
    {
        if (count == 15)
        {
            print("прошел");
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
