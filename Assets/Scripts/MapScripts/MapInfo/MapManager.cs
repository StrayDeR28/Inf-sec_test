using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject pepasanObject;
    private void Awake()
    {
        if (PlayerPrefs.GetString("levelIndex") == "done")
        {
            pepasanObject.GetComponent<PeposanAnimation>().ShowPepasan("winCase");
            PlayerPrefs.SetString("levelIndex", "");
        }
    }
}
