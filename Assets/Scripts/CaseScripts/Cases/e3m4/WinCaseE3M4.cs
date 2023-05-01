using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCaseE3M4 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    public void CaseWin()
    {
        if (answerInputField.text != null && (answerInputField.text.Replace(" ", "") == "1,4,2,3")) 
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
