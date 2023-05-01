using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinCaseE4M2 : MonoBehaviour
{
    [SerializeField] List<Drag4> rows;

    bool flag;

    public void CaseWin()
    {
        foreach (var row in rows)
        {
            flag = true;
            flag &= row.flag;
        }
        if(flag)
        {
            print("крутой");
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
