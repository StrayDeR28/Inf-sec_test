using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinCaseE5M1 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;
    public void CaseWin()
    {
        if (answerInputField.text != null && (answerInputField.text == "продает лучше" || answerInputField.text == "Продает лучше"))
        {
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
