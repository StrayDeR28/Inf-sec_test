using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PandasPart : MonoBehaviour
{
    [SerializeField] private GameObject colorHolder;
    [SerializeField] private string rightColor;
    [SerializeField] private bool colorRight = false;

    private string colorName;
    public void ChangeColor()
    {
        colorName = colorHolder.GetComponent<ColorHolder>().GetColor();
        SwitchColor();
        if (colorName == rightColor)
        {
            colorRight = true;
        }
        else
        {
            colorRight = false;
        }
    }
    public void SwitchColor()
    {
        switch (colorName)
        {
            case "color1":
                gameObject.GetComponent<Image>().color = new Color32(156, 156, 156, 255);//заменить на цвет дизайнеров
                break;
            case "color2":
                gameObject.GetComponent<Image>().color = new Color32(79, 79, 79, 255);//заменить на цвет дизайнеров
                break;
            case "color3":
                gameObject.GetComponent<Image>().color = new Color32(34, 34, 34, 255);//заменить на цвет дизайнеров
                break;
        }
    } 
    public bool GetColorRight()
    {
        return colorRight;
    }
}
