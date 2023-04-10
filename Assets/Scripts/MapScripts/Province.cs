using UnityEngine;

public class Province : MonoBehaviour
{
    public GameObject Task1, Task2, Task3, Task4;
    bool[] IsPassed = {false, false, false, false};
    [SerializeField] private ProvincesEnum ProvinceNumber;
    [SerializeField] private enum ProvincesEnum
    {
        Province1,
        Province2,
        Province3,
        Province4,
        Province5,
        Province6,
        Province7
    }
    void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            if(WebManager.player.progress[(int)ProvinceNumber * 4 + i] > 0) IsPassed[i] = true;
        }
    }
    public void ActiveTasks()
    {
        if(!IsPassed[0])
        {
            Task1.SetActive(true);
        }
        if(!IsPassed[1])
        {
            Task2.SetActive(true);
        }
        if(!IsPassed[2])
        {
            Task3.SetActive(true);
        }
        if(!IsPassed[3])
        {
            Task4.SetActive(true);
        }
    }
    public void UnActiveTasks()
    {
        Task1.SetActive(false);
        Task2.SetActive(false);
        Task3.SetActive(false);
        Task4.SetActive(false);
    }
}
