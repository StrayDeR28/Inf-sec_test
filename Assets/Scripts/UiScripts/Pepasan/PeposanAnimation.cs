using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeposanAnimation : MonoBehaviour
{
    [SerializeField] private List<Image> sprites;
    [SerializeField] private GameObject pepasanDown;
    [SerializeField] private GameObject pepasanTalk;

    private string state = "hidden";//состояния, для передачи между скриптами

    float currentTime = 0;
    private Animator animator;
    bool flagAppear = true;

    public void ChangeImageIdle()
    {
        int randomNumber = GetRandomListElement();
        pepasanDown.GetComponent<Image>().sprite = sprites[randomNumber].sprite;
        pepasanTalk.GetComponent<Image>().sprite = sprites[randomNumber].sprite;
    }
    public void ChangeImageHint()
    {
        pepasanDown.GetComponent<Image>().sprite = sprites[sprites.Count - 1].sprite;
        pepasanTalk.GetComponent<Image>().sprite = sprites[sprites.Count - 1].sprite;
    }

    public void ShowPepasan(string textContent)
    {
        if (flagAppear == true)
        {
            if ((pepasanDown.GetComponent<Image>().sprite == sprites[sprites.Count - 1].sprite) && (pepasanTalk.GetComponent<Image>().sprite == sprites[sprites.Count - 1].sprite))//проверка на спрайт "подсказки"
            {
                ChangeImageIdle();
            }
            animator = GetComponent<Animator>();
            animator.SetTrigger("Appear");
            flagAppear = false;
            pepasanTalk.GetComponent<PeposanTalk>().Talk(textContent);
            state = "appeared";
            StartCoroutine("HidePepasanEnum");
        }
    }
    
    public IEnumerator HidePepasanEnum()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            currentTime += Time.deltaTime;
            if (currentTime >= 10.0)//Время, через которое анимация сменится
            {
                currentTime = 0;
                animator.SetTrigger("Disappear");
                flagAppear = true;
                state = "hidden";
                StopAllCoroutines();
            }
        }
    }
    public void ResetTime()//вызывается нажатием на кнопку
    {
        StopAllCoroutines();
        currentTime = 0;
        StartCoroutine("HidePepasanEnum");
    }
    public string GetState()
    {
        return state;
    }
    public int GetRandomListElement()
    {
        int randomNum = UnityEngine.Random.Range(0, sprites.Count-1);
        return randomNum;
    }
}