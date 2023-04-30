using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCaseE4M4 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;

    public void CaseWin()
    {
        if(answerInputField.text == "5")
        {
            print("крутой");
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
