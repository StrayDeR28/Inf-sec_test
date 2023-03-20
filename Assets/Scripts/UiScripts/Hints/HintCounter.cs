using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintCounter : MonoBehaviour
{
    [SerializeField] int hintsCount;
    [SerializeField] GameObject pepasanObject;
    private void Awake()
    {
        //getCurrentHints - обратиться к беку за кол-вом подсказок
        hintsCount = 3;
        gameObject.GetComponentInChildren<TMP_Text>().text = hintsCount.ToString();
    }
    public void UseHint()
    {
        if (hintsCount > 0 && pepasanObject.GetComponent<PeposanAnimation>().GetState() == "hidden")
        {
            pepasanObject.GetComponent<PeposanAnimation>().ShowPepasan("hint");
            hintsCount--;
            gameObject.GetComponentInChildren<TMP_Text>().text = hintsCount.ToString();
        }
        else if(hintsCount == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        //postCurrentHints - передаём на бек кол-во подсказок
    }
}
