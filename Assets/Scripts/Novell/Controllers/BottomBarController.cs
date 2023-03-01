using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state = State.COMPLETED;

    private string playerName = "Иван";//Добавить метод получения с Бекенда имени. Убрать значение по умолчанию

    private enum State
    {
        PLAYING, COMPLETED
    }


    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {  
        if (currentScene.sentences[++sentenceIndex].text.EndsWith("&name"))//++ Проверка для ввода имени пользователя/пройденых проввинций
        {

            string tmpText = currentScene.sentences[sentenceIndex].text;
            tmpText = tmpText.Substring(0, tmpText.Length-5);
            tmpText = tmpText + " " + playerName;

            currentScene.sentences.Insert(sentenceIndex, new StoryScene.Sentence(tmpText, currentScene.sentences[sentenceIndex].speaker));
            currentScene.sentences.RemoveAt(sentenceIndex+1);
        }
        StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text));//++
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
