using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PeposanAnimation : MonoBehaviour
{
    [SerializeField] GameObject pepasanTalk;

    private string state = "hidden";//состояния, для передачи между скриптами

    float currentTime = 0;
    private Animator animator;
    bool flagAppear = true;

    public void ShowPepasan(string textContent)
    {
        if (flagAppear == true)
        {
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
            if (currentTime >= 10.0)//Время, через которое анимация смениться
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
}