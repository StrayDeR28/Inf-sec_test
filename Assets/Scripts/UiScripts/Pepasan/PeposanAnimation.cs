using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PeposanAnimation : MonoBehaviour
{
    [SerializeField] private List<Image> sprites;
    [SerializeField] private GameObject pepasanDown;
    [SerializeField] private GameObject pepasanTalk;

    private string state = "hidden";//состояния, для передачи между скриптами

    float currentTime = 0;
    private Animator animator;
    bool flagAppear = true;
    Sprite oldSprite;
    Sprite newSprite;


    public void ChangeImageIdle()
    {
        int randomNumber = GetRandomListElement();
        oldSprite = pepasanTalk.GetComponent<Image>().sprite;
        newSprite = sprites[randomNumber].sprite;
        if (newSprite != oldSprite)
        {
            pepasanDown.GetComponent<Image>().sprite = sprites[randomNumber].sprite;
            DOTween.Sequence()
            .Append(pepasanTalk.GetComponent<Image>().DOFade(0.4f,0.25f))
            .AppendCallback(ChangeImage)
            .Append(pepasanTalk.GetComponent<Image>().DOFade(1,0.25f));
        }
    }
    public void ChangeImageHint()
    {
        pepasanDown.GetComponent<Image>().sprite = sprites[sprites.Count - 1].sprite;
        pepasanTalk.GetComponent<Image>().sprite = sprites[sprites.Count - 1].sprite; 
    }
    private void ChangeImage()
    {
        pepasanTalk.GetComponent<Image>().sprite = newSprite;
    }

    public void ShowPepasan(string textContent)
    {
        if (flagAppear == true)
        {
            oldSprite = pepasanTalk.GetComponent<Image>().sprite;
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