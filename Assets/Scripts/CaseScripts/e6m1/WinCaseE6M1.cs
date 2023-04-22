using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCaseE6M1 : MonoBehaviour
{
    [SerializeField] private int pieceCounter=0;
    public void SetPieceCounter()
    {
        pieceCounter++;
    }
    public void CaseWin()
    {
        if ( pieceCounter == 16 )//кол-во элементов для завершения
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
