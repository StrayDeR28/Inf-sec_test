using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAndSendInfo : MonoBehaviour
{
    [SerializeField] private ScenesEnum LoadNextScene = ScenesEnum.Registration;

    [SerializeField] private enum ScenesEnum {None=0, Registration=1, Novell1=2, Map=3};
    public void LoadScene()
    {
        if (gameObject.GetComponent<RegistrationInfo>().GetAuthCheck() == true)//Проверка только на авторизованность пользователя. Чтобы работало без задержки,
                                                                               //нужно этот метод вызывать из RegistrationInfo, после проверк авторизации, а не как сейчас - по кнопке
        {
            switch (LoadNextScene)
            {
                case ScenesEnum.Registration:
                    SceneManager.LoadScene("RegistrationScene");
                    break;
                case ScenesEnum.Novell1:
                    SceneManager.LoadScene("NovellScene");
                    break;
                /*case ScenesEnum.Map:
                    //SceneManager.LoadScene("MapScene");
                    break;*/
            }
        }
    }
}
