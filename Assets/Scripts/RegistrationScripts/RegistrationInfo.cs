using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegistrationInfo : MonoBehaviour
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;

    public void SendLogin()
    {
        //код Германа
        print("login:"+login.text);
    }
    public void SendPassword()
    {
        //код Германа
        print("password"+password.text);
    }
    public void SendName()
    {
        //код Германа
    }
    public void SendSurname()
    {
        //код Германа
    }
    public void SendPatronymic()
    {
        //код Германа
    }
    public void BackendReport()
    {
        // метод для вывода информации о регистрации (успешно, не успешно...)
    }
}
