using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCaseE4M3 : MonoBehaviour
{
    [SerializeField] private TMP_InputField answerInputField;

    public void CaseWin()
    {
        if(answerInputField.text == "HJE, CTF, 2802" || answerInputField.text == "hje, ctf, 2802") // ", , 3039"
        {
            print("крутой");
            gameObject.GetComponent<WinCase>().WinCasePlayerPrefs();
        }
    }
}
