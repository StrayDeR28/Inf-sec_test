using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class WebManager : MonoBehaviour
{
    string www = "http://localhost/pudge/signup.php";

    public UnityEvent OnError;

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
        form.AddField("firstname", window.firstName.text);
        form.AddField("middlename", window.middleName.text);
        form.AddField("lastname", window.lastName.text);
        form.AddField("email", window.email.text);
        form.AddField("nickname", window.nickName.text);
        form.AddField("password", window.password.text);

        StartCoroutine(SendData(form));
    }
    public void DataUpdate(string field, int value)
    {
        WWWForm form = new WWWForm();

        form.AddField("submit", "update");
        form.AddField("id", player.id);
        form.AddField("field", field);
        form.AddField(field, value);

        StartCoroutine(SendData(form));
    }

    IEnumerator SendData(WWWForm form)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(www, form))
        {
            yield return request.SendWebRequest();

            //while(!request.isDone) yield return null;

            if(request.result != UnityWebRequest.Result.Success) //зокментировать до else
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                player = JsonUtility.FromJson<PlayerData>(request.downloadHandler.text); // закоментировать
                
                if(player.error == ErrorCode.none)
                {   
                    if(!player.novel1) gameObject.GetComponent<SceneLoader>().StringToEnum("NovellScene1");
                    else if (player.novel2) gameObject.GetComponent<SceneLoader>().StringToEnum("NovellScene2");
                    else gameObject.GetComponent<SceneLoader>().StringToEnum("Map");
                }
                else OnError.Invoke();
            }
        }
    }
}
