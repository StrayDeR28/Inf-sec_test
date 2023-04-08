using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintCounter : MonoBehaviour
{
    [SerializeField] private int hintsCount;
    [SerializeField] private int currentLevel;
    [SerializeField] private GameObject pepasanObject;
    [SerializeField] private GameObject pepasanTextObject;

    [SerializeField] private WebManager webManager;

    private bool pickedOnce=true; 
    private void Awake()
    {
        //getCurrentHints - обратиться к беку за кол-вом подсказок
        hintsCount = WebManager.player.hints;
        gameObject.GetComponentInChildren<TMP_Text>().text = hintsCount.ToString();
    }
    public void UseHint()
    {
        if (hintsCount > 0 && pepasanObject.GetComponent<PeposanAnimation>().GetState() == "hidden")
        {
            pepasanTextObject.GetComponent<PeposanTalk>().TakeElementNumber(currentLevel);
            pepasanObject.GetComponent<PeposanAnimation>().ShowPepasan("hint");
            pepasanObject.GetComponent<PeposanAnimation>().ChangeImageHint();
            if (pickedOnce)
            {
                hintsCount--;
                webManager.DataUpdate("hints", hintsCount);
                WebManager.player.hints = hintsCount;
                gameObject.GetComponentInChildren<TMP_Text>().text = hintsCount.ToString();
                pickedOnce=false;
            }
        }
        else if(hintsCount == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        //postCurrentHints - передаём на бек кол-во подсказок
    }
    public void TakeCurrentLevel(int curLevel)
    {
        currentLevel = curLevel;
    }
}
