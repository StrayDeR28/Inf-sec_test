using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeposanTalk : MonoBehaviour
{
    [SerializeField] PepasansTextObject timesUpText;
    [SerializeField] PepasansTextObject hintsText;
    [SerializeField] PepasansTextObject supportPhrasesText;
    [SerializeField] PepasansTextObject winCaseText;
    [SerializeField] PepasansTextObject newTitleText;
    public void Talk(string textContent)//переделать
    {
        switch(textContent)
        { 
            case "stopwatch":
                gameObject.GetComponentInChildren<TMP_Text>().text = GetRandomListElement(timesUpText);
                break;
            case "hint":
                gameObject.GetComponentInChildren<TMP_Text>().text = GetRandomListElement(hintsText);
                break;
            case "supportPhrase":
                gameObject.GetComponentInChildren<TMP_Text>().text = GetRandomListElement(supportPhrasesText);
                break;
            case "winCase":
                gameObject.GetComponentInChildren<TMP_Text>().text = GetRandomListElement(winCaseText);
                break;
            case "newTitle":
                gameObject.GetComponentInChildren<TMP_Text>().text = GetRandomListElement(newTitleText);
                break;
        }
    }
    public string GetRandomListElement(PepasansTextObject textObject)
    {
        int randomNum = Random.Range(0, textObject.sentences.Count);
        return textObject.sentences[randomNum];
    }
}
