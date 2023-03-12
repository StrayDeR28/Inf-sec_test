using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeposanTalk : MonoBehaviour
{
    int i=0;
    public void Talk()//переделать
    {
        switch (i)
            { 
                case 0:
                gameObject.GetComponentInChildren<TMP_Text>().text = ("fedya lox");
                break;

                case 1:
                gameObject.GetComponentInChildren<TMP_Text>().text = ("a mozhet ты лох?");
                break;
        }
        i++;
    }
}
