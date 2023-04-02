using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PepasanTutorial : MonoBehaviour
{
    [SerializeField] private GameObject pepasanTalkTutorial;
    [SerializeField] private GameObject pepasanObject;

    [SerializeField] private GameObject progressbarBackground;
    [SerializeField] private GameObject provinceBackground;
    [SerializeField] private GameObject caseBackground;
    [SerializeField] private GameObject mainBackground;

    private int step = 0;
    public void TutorialNextStep()
    {
        step++;
        if (step <= 5)
        {
            switch (step)
            {
                case 1:
                    mainBackground.SetActive(false);
                    progressbarBackground.SetActive(true);
                    break;
                case 2:
                    progressbarBackground.SetActive(false);
                    provinceBackground.SetActive(true);
                    pepasanTalkTutorial.GetComponent<Button>().interactable=false;
                    break;
                case 3:
                    provinceBackground.SetActive(false);
                    mainBackground.SetActive(true);
                    pepasanTalkTutorial.GetComponent<Button>().interactable = true;
                    break;
                case 5:
                    mainBackground.SetActive(false);
                    caseBackground.SetActive(true);
                    TempStaticClass.tutorialDoneFlag = true;//временны класс. В финале замениться кодом Германа
                    break;
            }
            pepasanTalkTutorial.GetComponent<PeposanTalk>().TakeElementNumber(step);
            gameObject.GetComponent<PeposanAnimation>().PlayPepasanSequence("tutorial");
        }
    }
    public void DestroyAll()
    {
        Destroy(progressbarBackground);
        Destroy(provinceBackground);
        Destroy(caseBackground);
        Destroy(mainBackground);
        Destroy(gameObject);
    }
}
