using CodeMonkey;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private LoadingIndicatorSO loadingIndicatorSO;
    private string sceneName;
    [SerializeField] private ScenesEnum LoadNextScene = ScenesEnum.Registration;

    [SerializeField] private enum ScenesEnum {None=0, Registration=1, Novell1=2, Map=3, Case=4, Novell2=5};
    public void LoadScene()
    {
        Time.timeScale = 1f;
        switch (LoadNextScene)
        {
            case ScenesEnum.Registration:
                sceneName = "RegistrationScene";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Novell1:
                sceneName = "NovellScene1";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Map:
                sceneName = "MapScene";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Case:
                sceneName = "CaseSceneMain";
                StartCoroutine(LoadSceneAsync());
                break;
            case ScenesEnum.Novell2:
                sceneName = "NovellScene2";
                StartCoroutine(LoadSceneAsync());
                break;
        }
    }
    public void StringToEnum( string str)
    {
        switch (str)
        {
            case "RegistrationScene":
                LoadNextScene = ScenesEnum.Registration;
                LoadScene();
                break;
            case "NovellScene1":
                LoadNextScene = ScenesEnum.Novell1;
                LoadScene();
                break;
            case "NovellScene2":
                LoadNextScene = ScenesEnum.Novell2;
                break;
        }
    }
    public IEnumerator LoadSceneAsync()
    {
        Instantiate(loadingIndicatorSO.loadingIndicator);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}