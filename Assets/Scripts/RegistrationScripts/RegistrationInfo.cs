using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RegistrationInfo : MonoBehaviour
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField nickname;
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField surname;
    [SerializeField] private TMP_InputField patronymic;
    [SerializeField] private TMP_Text debugText;

    private bool infoCheck = false;

    [SerializeField] private CheckInfoEnum CheckInput = CheckInfoEnum.None;

    [SerializeField] private enum CheckInfoEnum { None = 0, LoginInfo = 1, RegistrationInfo = 2 };

    public void CheckInfo()
    {
        switch (CheckInput)
        {
            case CheckInfoEnum.LoginInfo:
                if (login.text.Length != 0 && password.text.Length != 0) { infoCheck = true; } 
                break;
            case CheckInfoEnum.RegistrationInfo:
                if (login.text.Length != 0 && password.text.Length != 0 && nickname.text.Length != 0 && userName.text.Length != 0 && surname.text.Length != 0 && patronymic.text.Length != 0) { infoCheck = true; }
                break;
        }
    }

    public void SendLogin()
    {
        //код Германа
        print("login: " + login.text);
    }
    public void SendPassword()
    {
        //код Германа
        print("password: " + password.text);
    }
    public void SendNickname()
    {
        //код Германа
        print("nickname: " + nickname.text);
    }
    public void SendName()
    {
        //код Германа
        print("Name: " + userName.text);
    }
    public void SendSurname()
    {
        //код Германа
        print("Surname: " + surname.text);
    }
    public void SendPatronymic()
    {
        //код Германа
        print("Patronymic: " + patronymic.text);
    }
    public void ErrorInputInfo()
    {
        // метод для вывода информации о регистрации (успешно, не успешно...)
        debugText.text = "Заполните поля ввода";
    }
    public bool GetInfoCheck()
    {
        return(infoCheck);
    }
}
