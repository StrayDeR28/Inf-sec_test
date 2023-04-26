using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCaseE4M3 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;

    public void CaseWin()
    {
        if(answerInputField.text == "1, 1, 1") // ", , 3039"
        {
            print("крутой");
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
