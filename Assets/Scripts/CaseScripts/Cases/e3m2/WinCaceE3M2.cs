using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCaceE3M2 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    public void CaseWin()
    {
        if (answerInputField.text != null && (answerInputField.text == "21")) 
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
