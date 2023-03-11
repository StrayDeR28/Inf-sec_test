using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    bool activeMenu = false;

    public GameObject MenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (activeMenu)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
        activeMenu = false;
    }
    public void Pause() 
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        activeMenu = true;
    }
}
