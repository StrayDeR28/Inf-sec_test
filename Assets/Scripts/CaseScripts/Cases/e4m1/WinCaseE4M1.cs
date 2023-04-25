using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCaseE4M1 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;

    public void CaseWin()
    {
        if(answerInputField.text == "8")
        {
            print("крутой");
            //gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        } else print("лох");
    }
}
