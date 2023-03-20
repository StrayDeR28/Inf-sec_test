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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && activeNewRankMenu)
        {
            Resume();
        }
    }
    public void Resume()
    {
        DOTween.Sequence()
        .Append(NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(0,0,0), 2))
        .Append(NewRankScreen.GetComponent<Image>().DOColor(new Color(0,0,0,0), 1))
        .AppendCallback(Animation);
    }
    public void Pause() 
    {
        DOTween.Sequence()
        .AppendCallback(Animation)
        .Append(NewRankScreen.GetComponent<Image>().DOColor(new Color(0,0,0,0.5f), 1))
        .Append(NewRankMenu.GetComponent<RectTransform>().DOScale(new Vector3(1,1,1), 2));
    }
    private void Animation()
    {
        activeNewRankMenu = !activeNewRankMenu;
        NewRankScreen.SetActive(activeNewRankMenu);
    }
}
