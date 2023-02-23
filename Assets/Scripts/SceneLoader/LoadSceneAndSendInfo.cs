using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAndSendInfo : MonoBehaviour
{
    [SerializeField] private int inputInt;
    public enum Scenes { Registration = 0, Novell1 = 1, Map = 2 };
    public void LoadScene()
    {
        if (inputInt == ((int)Scenes.Registration))
        {
            SceneManager.LoadScene("RegistrationScene");
        }
        else if (inputInt == ((int)Scenes.Novell1))
        {
            SceneManager.LoadScene("NovellScene");
        }
        else if (inputInt == ((int)Scenes.Map))
        {
            //SceneManager.LoadScene("MapScene");
        }
    }
}
