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

    [SerializeField] private WebManager webManager;
    void Awake()
    {
        bits.SetText((WebManager.player.bits%8).ToString());
        bytes.text = (WebManager.player.bits/8).ToString();
        UpdateProgress();
        SetNewRank();
        switch (WebManager.player.rank)
        {
            case RankCode.middle:
                NewRankMiddle.GetComponent<NewRank>().Pause();
                break;
            case RankCode.senior:
                NewRankSenior.GetComponent<NewRank>().Pause();
                break;
            case RankCode.samurai:
                Congratulations.GetComponent<NewRank>().Pause();
                break;
        }
        /*if(WebManager.player.bits%8 == 0)
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
        }*/
    }
    public void SetNewRank()
    {
        if (WebManager.player.rank == RankCode.junior && WebManager.player.bits >= 24)
        {
            webManager.DataUpdate("rank", 1);
            WebManager.player.rank = RankCode.middle;
        }
        else if (WebManager.player.rank == RankCode.middleEarn && WebManager.player.bits >= 40)
        {
            webManager.DataUpdate("rank", 3);
            WebManager.player.rank = RankCode.senior;
        }
        else if (WebManager.player.bits >= 56)
        {
            webManager.DataUpdate("rank", 5);
            WebManager.player.rank = RankCode.samurai;
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
