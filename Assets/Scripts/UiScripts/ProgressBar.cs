using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public TextMeshProUGUI bits;
    public TextMeshProUGUI bytes;
    public GameObject NewRankMiddle;
    public GameObject NewRankSenior;
    public GameObject Congratulations;
    public Slider slider;

    
    void Awake()
    {
        bits.SetText((WebManager.player.bits%8).ToString());
        bytes.text = (WebManager.player.bits/8).ToString();
        UpdateProgress();
        if(WebManager.player.bits%8 == 0)
        {
            switch (WebManager.player.bits/8)
            {
                case 3:
                    NewRankMiddle.GetComponent<NewRank>().Pause();
                    break;
                case 5:
                    NewRankSenior.GetComponent<NewRank>().Pause();
                    break;
                case 7:
                    Congratulations.GetComponent<NewRank>().Pause();
                    break;
            }
        }
    }
    public void UpdateProgress()
    {
        slider.value = WebManager.player.bits;
    }
    public void ProgressForTutorial(string tutorialProgress)
    {
        switch (tutorialProgress)
        {
            case "showMiddle": 
                slider.value = 24; 
                break;
            case "showSenior":
                slider.value = 40;
                break;
            case "showSamurai":
                slider.value = 56;
                break;
        }
    }
}
