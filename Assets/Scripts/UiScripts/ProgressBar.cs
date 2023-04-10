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
    int progress;
    void Awake()
    {
        bits.SetText((WebManager.player.bits%8).ToString());
        bytes.text = (WebManager.player.bits/8).ToString();
        /*if(WebManager.player.bits%8 == 0)
        {
            switch (WebManager.player.bits/8)
            {
                case 1:
                    NewRankMiddle.GetComponent<NewRank>().Pause();
                    break;
                case 3:
                    NewRankSenior.GetComponent<NewRank>().Pause();
                    break;
                case 4:
                    Congratulations.GetComponent<NewRank>().Pause();
                    break;
            }
        }*/
    }
//для отладки
    public void UpdateProgress()
    {
        progress++;
        slider.value = progress;
    }

}
