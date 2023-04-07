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
    [SerializeField] private PepasansTextObject tutorialText;

    private int elementNumber;
    private int currentListIndex;
    private void Awake()
    {
        elementNumber = 0;
    }
    public void Talk(string textContent)
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
            case "tutorial":
                gameObject.GetComponentInChildren<TMP_Text>().text = tutorialText.sentences[elementNumber];
                break;
        }
    }
    public string GetRandomListElement(PepasansTextObject textObject)
    {   
        int randomNumber = -1;
        while (randomNumber == -1 || currentListIndex == randomNumber)
        {
            randomNumber = Random.Range(0, textObject.sentences.Count);
        }
        currentListIndex = randomNumber;
        return textObject.sentences[currentListIndex];    
    }
    public void TakeElementNumber(int elNumber)
    {
        elementNumber = elNumber;
    }
}
