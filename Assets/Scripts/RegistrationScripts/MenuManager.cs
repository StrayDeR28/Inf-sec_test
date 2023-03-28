using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [System.Serializable]
    public struct MenuLogin
    {
        public TMP_InputField email, password;
        public TMP_Text errorText;
    }

    [System.Serializable]
    public struct MenuSignup
    {
        public TMP_InputField firstname, middlename, lastname, email, nickname, password;
        public Toggle toggleLastName, togglePrivacy;
        public TMP_Text errorText;
    }

    public MenuLogin loginWindow;
    public MenuSignup signupWindow;
    
    public WebManager webManager;



    public void Login()
    {
        //webManager.Login(loginWindow);
        gameObject.GetComponent<SceneLoader>().StringToEnum("NovellScene1");
    }
    public void Signup()
    {
        webManager.Signup(signupWindow);
    }

    bool CheckLogin(MenuManager.MenuLogin window)
    {
        return  window.email.text.Length != 0 && 
                window.password.text.Length != 0;
    }
    bool CheckSignup(MenuManager.MenuSignup window)
    {
        return  window.email.text.Length != 0 &&
                window.nickname.text.Length != 0 &&
                window.password.text.Length != 0 &&
                window.firstname.text.Length != 0 &&
                window.middlename.text.Length != 0 &&
                window.togglePrivacy.isOn &&
                (window.toggleLastName.isOn ||
                window.lastname.text.Length != 0);
    }
}
