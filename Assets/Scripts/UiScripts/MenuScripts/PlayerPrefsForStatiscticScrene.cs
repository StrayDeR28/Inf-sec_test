using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsForStatiscticScrene : MonoBehaviour
{
    public void SetPlayerForStatiscticScrene()//на сцене Statisctic провериться - отображение кнопки вернуться на карту
    {
        PlayerPrefs.SetString("ShowReturnMapButton","true");
    }
}
