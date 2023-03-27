using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    [SerializeField] private CaseListSO prefabList;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject winScrene;

    private void Awake()
    {
        int caseNumber = int.Parse(PlayerPrefs.GetString("levelIndex"));
        Instantiate(prefabList.cases[caseNumber], canvas.transform);
        StartCoroutine(WaitForCaseComplete());

    }
    public IEnumerator WaitForCaseComplete()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            if(PlayerPrefs.GetString("levelIndex") == "done")
            {
                winScrene.SetActive(true);
                StopCoroutine(WaitForCaseComplete());
            }
        }
    }
}
