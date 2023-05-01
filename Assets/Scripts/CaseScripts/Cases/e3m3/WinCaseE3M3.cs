using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCaseE3M3 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    public void CaseWin()
    {
        if (answerInputField.text != null && ((answerInputField.text == "9-C") || (answerInputField.text == "9-c"))) 
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
