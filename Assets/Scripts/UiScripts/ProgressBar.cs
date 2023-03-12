using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public TextMeshProUGUI bits;
    public TextMeshProUGUI bytes;
    public GameObject canvas;
    public Slider slider;
    int progress;
    public void OnSliderChanged()
    {
        bits.SetText((progress%8).ToString());
        bytes.text = (progress/8).ToString();
        /*switch (progress/8)
        {
            case 1:
                canvas.GetComponent<NewRank>().Pause();
                break;
            case 2:
                canvas.GetComponent<NewRank>().Pause();
                break;
            case 3:
                canvas.GetComponent<NewRank>().Pause();
                break;
        }*/
        if(progress%8 == 0)
        {
            canvas.GetComponent<NewRank>().Pause();
        }
    }
    public void UpdateProgress()
    {
        progress++;
        slider.value = progress;
    }

}
