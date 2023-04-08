using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    public string www;

    public MenuManager menu;

    enum ActionType {Login, Signup, Update}

    public static PlayerData player = new PlayerData();

    public void Login(MenuManager.MenuLogin window)
    {
        WWWForm form = new WWWForm();

        form.AddField("submit", "login");
        form.AddField("email", window.email.text);
        form.AddField("password", window.password.text);

        StartCoroutine(SendData(form, ActionType.Login));
    }
    public void Signup(MenuManager.MenuSignup window)
    {
        WWWForm form = new WWWForm();

        form.AddField("submit", "signup");
        form.AddField("firstname", window.firstName.text);
        form.AddField("middlename", window.middleName.text);
        form.AddField("lastname", window.lastName.text);
        form.AddField("email", window.email.text);
        form.AddField("nickname", window.nickName.text);
        form.AddField("password", window.password.text);

        StartCoroutine(SendData(form, ActionType.Signup));
    }

    public void Update()
    {

    }

    IEnumerator SendData(WWWForm form, ActionType type)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(www, form))
        {
            yield return request.SendWebRequest();

            //while(!request.isDone) yield return null;

            if(request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                player = JsonUtility.FromJson<PlayerData>(request.downloadHandler.text);
                
                switch(type)
                {
                    case ActionType.Login:
                        switch(player.error)
                        {
                            case ErrorCode.loginEmailError:
                                menu.loginWindow.emailError.gameObject.SetActive(true);
                                menu.loginWindow.email.image.sprite = menu.errorLongField;
                                break;
                            case ErrorCode.loginPassError:
                                menu.loginWindow.passwordError.gameObject.SetActive(true);
                                menu.loginWindow.password.image.sprite = menu.errorLongField;
                                break;
                            default:
                                // сцена
                                print("красава");
                                break;
                        }
                        break;
                    case ActionType.Signup:
                        switch(player.error)
                        {
                            case ErrorCode.signupEmailError:
                                menu.signupWindow.emailError.gameObject.SetActive(true);
                                menu.signupWindow.email.image.sprite = menu.errorLongField;
                                break;
                            case ErrorCode.signupNickError:
                                menu.signupWindow.nicknameError.gameObject.SetActive(true);
                                menu.signupWindow.nickName.image.sprite = menu.errorLongField;
                                break;
                        }
                        break;
                }
            }
        }
    }
}
