using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    [SerializeField] private CaseListSO prefabList;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject winScrene;
    [SerializeField] private GameObject stopwatch;
    [SerializeField] private GameObject hints;

    private int caseNumber;

    private void Awake()
    {
        caseNumber = int.Parse(PlayerPrefs.GetString("levelIndex"));
        Instantiate(prefabList.cases[caseNumber], canvas.transform);
        StartCoroutine(WaitForCaseComplete());
        SendlevelIndextoHints();
    }
    public IEnumerator WaitForCaseComplete()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            if(PlayerPrefs.GetString("levelIndex") == "done")
            {
                stopwatch.GetComponent<Stopwatch>().StopStopwatch();
                winScrene.GetComponent<CountRatingPoints>().TakeDifficultyLevel(caseNumber);
                winScrene.SetActive(true);
                StopCoroutine(WaitForCaseComplete());
            }
        }
    }
    public void SendlevelIndextoHints()
    {
        hints.GetComponent<HintCounter>().TakeCurrentLevel(caseNumber);
    }
}
