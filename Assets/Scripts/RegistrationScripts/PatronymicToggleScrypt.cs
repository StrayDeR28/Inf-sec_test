using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatronymicToggleScrypt : MonoBehaviour
{
    [SerializeField] private TMP_InputField patronymic;

    public void SetActive()
    {
        if(gameObject.GetComponent<Toggle>().isOn == true)
        {
            patronymic.interactable=false;
        }
        else
        {
            patronymic.interactable=true;
        }
    }
}
