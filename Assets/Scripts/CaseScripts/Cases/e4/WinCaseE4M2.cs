using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinCaseE4M2 : MonoBehaviour
{
    

    public void CaseWin()
    {
        gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
    }
}
