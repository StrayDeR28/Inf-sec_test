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
    public void OnSliderChanged()
    {
        bits.SetText((progress%8).ToString());
        bytes.text = (progress/8).ToString();
        if(progress%8 == 0)
        {
            switch (progress/8)
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
        }
    }
//для отладки
    public void UpdateProgress()
    {
        progress++;
        slider.value = progress;
    }

}
