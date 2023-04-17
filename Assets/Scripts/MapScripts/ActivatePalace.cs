using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePalace : MonoBehaviour
{
    private int bits;
    private void Awake()
    {
        bits = WebManager.player.bits;
        if (bits >= 24)
        {
            gameObject.GetComponent<Button>().interactable = true;//мейби добавить эффект
        }
    }
}