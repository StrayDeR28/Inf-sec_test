using UnityEngine;

public class Province : MonoBehaviour
{
    public GameObject Task1, Task2, Task3, Task4;
    public void ActiveTasks(){
        Task1.SetActive(true);
        Task2.SetActive(true);
        Task3.SetActive(true);
        Task4.SetActive(true);
    }
    public void UnActiveTasks(){
        Task1.SetActive(false);
        Task2.SetActive(false);
        Task3.SetActive(false);
        Task4.SetActive(false);
    }
}
