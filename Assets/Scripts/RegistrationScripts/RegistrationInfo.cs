using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegistrationInfo : MonoBehaviour
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField password2;
    [SerializeField] private TMP_InputField uName;
    [SerializeField] private TMP_InputField surname;
    [SerializeField] private TMP_InputField patronymic;
    [SerializeField] private TMP_Text debugText;


    public void SendLogin()
    {
        //код Германа
        print("login: "+login.text);
    }
    public void SendPassword()
    {
        //код Германа
        print("password: "+password.text);
    }
    public void SendPassword2()
    {
        //код Германа
        print("password2: " + password2.text);
    }
    public void SendName()
    {
        //код Германа
        print("Name: " + uName.text);
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
    public void BackendReport()
    {
        // метод для вывода информации о регистрации (успешно, не успешно...)
        debugText.text = "Регистрация успешна";
    }
    public void ComparePassword()
    {
        if(password.text==password2.text)
        {
            SendPassword();
            //код Германа, отправляющий пароль
            debugText.text = "";
        }
        else
        {
            debugText.text = "Пароли не совпадают";
        }
    }
}
