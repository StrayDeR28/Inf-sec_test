using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintCounter : MonoBehaviour
{
    [SerializeField] private int hintsCount;
    [SerializeField] private string currentLevel;
    [SerializeField] private GameObject pepasanObject;
    [SerializeField] private GameObject pepasanTextObject;

    private bool pickedOnce=true; 
    private void Awake()
    {
        //getCurrentHints - обратиться к беку за кол-вом подсказок
        //getCurrentLevel - обратиться к беку за информацией о текущем кейсе (вид "e1m1")
        hintsCount = 3;
        currentLevel = "e2m4";
        gameObject.GetComponentInChildren<TMP_Text>().text = hintsCount.ToString();
    }
    public void UseHint()
    {
        if (hintsCount > 0 && pepasanObject.GetComponent<PeposanAnimation>().GetState() == "hidden")
        {
            pepasanTextObject.GetComponent<PeposanTalk>().HintsStringToInt(currentLevel);
            pepasanObject.GetComponent<PeposanAnimation>().ShowPepasan("hint");
            pepasanObject.GetComponent<PeposanAnimation>().ChangeImageHint();
            if (pickedOnce)
            {
                hintsCount--;
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
}
