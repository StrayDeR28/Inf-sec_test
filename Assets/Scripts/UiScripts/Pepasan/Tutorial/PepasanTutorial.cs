using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PepasanTutorial : MonoBehaviour
{
    [SerializeField] private GameObject pepasanTalkTutorial;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private GameObject progressBar;

    [SerializeField] private GameObject progressbarBackground;
    [SerializeField] private GameObject provinceBackground;
    [SerializeField] private GameObject caseBackground;
    [SerializeField] private GameObject mainBackground;

    [SerializeField] private WebManager webManager;

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
                    nextTextButton.interactable = false;
                    break;
                case 3:
                    provinceBackground.SetActive(false);
                    provinceBackground.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                    progressbarBackground.SetActive(true);
                    nextTextButton.interactable = true;
                    break;
                case 5:
                    progressbarBackground.SetActive(false);
                    provinceBackground.SetActive(true);
                    caseBackground.SetActive(true);
                    
                    webManager.DataUpdate("tutorial", 1);
                    WebManager.player.tutorial = true;

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
