using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    public string www;

    public static PlayerData player = new PlayerData();

    public void Login(MenuManager.MenuLogin window)
    {
        WWWForm form = new WWWForm();

        form.AddField("submit", "login");
        form.AddField("email", window.email.text);
        form.AddField("password", window.password.text);

        StartCoroutine(SendData(form));
    }
    public void Signup(MenuManager.MenuSignup window)
    {
        WWWForm form = new WWWForm();

        form.AddField("submit", "signup");
        form.AddField("firstname", window.firstname.text);
        form.AddField("middlename", window.middlename.text);
        form.AddField("lastname", window.lastname.text);
        form.AddField("email", window.email.text);
        form.AddField("nickname", window.nickname.text);
        form.AddField("password", window.password.text);

        StartCoroutine(SendData(form));
    }

    IEnumerator SendData(WWWForm form)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(www, form))
        {
            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                player = JsonUtility.FromJson<PlayerData>(request.downloadHandler.text);
            }
        }
    }
}
