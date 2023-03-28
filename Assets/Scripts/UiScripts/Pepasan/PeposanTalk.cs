using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeposanTalk : MonoBehaviour
{
    [SerializeField] private PepasansTextObject timesUpText;
    [SerializeField] private PepasansTextObject hintsText;
    [SerializeField] private PepasansTextObject supportPhrasesText;
    [SerializeField] private PepasansTextObject winCaseText;
    [SerializeField] private PepasansTextObject newTitleText;

    private int elementNumber;
    public void Talk(string textContent)//переделать
    {
        switch(textContent)
        { 
            case "stopwatch":
                gameObject.GetComponentInChildren<TMP_Text>().text = GetRandomListElement(timesUpText);
                break;
            case "hint":
                gameObject.GetComponentInChildren<TMP_Text>().text = hintsText.sentences[elementNumber];
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
    public void TakeElementNumber(int elNumber)
    {
        elementNumber = elNumber;
    }
}
