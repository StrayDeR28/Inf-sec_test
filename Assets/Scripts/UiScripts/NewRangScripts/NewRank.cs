using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class NewRank : MonoBehaviour
{
    bool activeNewRankMenu = false;

    public GameObject NewRankScreen;
    public GameObject NewRankMenu;
    public GameObject RaysPartical;
    public GameObject WaysPartical;
    public GameObject DotsPartical;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && activeNewRankMenu)
        {
            Resume();
        }
    }
    public void Resume()
    {
        RaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 2);
        WaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 2);
        DotsPartical.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 2);
        NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 2);
        DOTween.Sequence()
        .Append(NewRankScreen.GetComponent<Image>().DOFade(0, 2))
        .AppendCallback(Animation);
    }
    public void Pause() 
    {
        Animation();
        RaysPartical.SetActive(activeNewRankMenu);
        NewRankScreen.GetComponent<Image>().DOFade(0.5f, 1);
        NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(1,1,1), 2);
        RaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 2);
        WaysPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 2);
        DotsPartical.GetComponent<RectTransform>().DOScale(new Vector3(10,10,0), 2);
    }
    private void ParticalOpen()
    {
        RaysPartical.SetActive(activeNewRankMenu);
        
    }
    private void ParticalClose()
    {
        RaysPartical.SetActive(!activeNewRankMenu);
    }
    private void Animation()
    {
        activeNewRankMenu = !activeNewRankMenu;
        NewRankScreen.SetActive(activeNewRankMenu);
    }
}
