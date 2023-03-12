using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{   
    float currentTime = 0;
    [SerializeField] private TMP_Text currentTimeText;

    public IEnumerator RunStopwatch()
    {   
        while (true)
        {
            yield return new WaitForSeconds(0);
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.ToString(@"mm\:ss");
        }//если понадобиться - добавить проверку на время и отправить об этм инфу морской свинке
    }
    public void StartStopwatch()
    {
        StartCoroutine("RunStopwatch");
    }
    public void StopStopwatch()
    {
        StopAllCoroutines();
    }
    public float GetCurrentTime()//обращаемся к этому при запросе времени
    {
        return currentTime;
    }
}
