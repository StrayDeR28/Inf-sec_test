using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticManager : MonoBehaviour
{
    [SerializeField] private Button backToMapButton;
    private void Awake()
    {
        if (PlayerPrefs.GetString("ShowReturnMapButton") == "true")
        {
            backToMapButton.gameObject.SetActive(true);
            PlayerPrefs.SetString("ShowReturnMapButton", "false");
        }
    }
}
