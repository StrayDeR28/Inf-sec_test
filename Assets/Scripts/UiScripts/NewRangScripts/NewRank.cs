using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRank : MonoBehaviour
{
    bool activeNewRankMenu = false;

    public GameObject NewRankMenu;
    public Slider ProgressBar;
    
    void Update()
    {
        if (ProgressBar.value / 8 == 0 && ProgressBar.value != 0)
        {
            Pause();
        }
    }
    public void Resume()
    {
        NewRankMenu.SetActive(false);
        Time.timeScale = 1f;
        activeNewRankMenu = false;
    }
    public void Pause() 
    {
        NewRankMenu.SetActive(true);
        Time.timeScale = 0f;
        activeNewRankMenu = true;
    }
}
