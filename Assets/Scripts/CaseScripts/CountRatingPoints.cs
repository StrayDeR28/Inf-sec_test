using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountRatingPoints : MonoBehaviour
{
    [SerializeField] private GameObject timeGO;
    [SerializeField] private int ratingPoints;
    private PointsEnum difficultyLevel;

    [SerializeField] private enum PointsEnum {Easy = 10, Medium = 20, Hard = 40};//макс значение очков рейтинга за уровень
    private void Awake()
    {
        CalculateRatingPoints();
    }
    public int GetRatingPoints()//Это передать на сервер
    {
        return ratingPoints;
    }
    public void TakeDifficultyLevel(int difLevel)
    {
        switch (difLevel%4)
        {
            case 0:
                difficultyLevel = PointsEnum.Easy;
                break;
            case 1:
                difficultyLevel = PointsEnum.Easy;
                break;
            case 2:
                difficultyLevel = PointsEnum.Medium;
                break;
            case 3:
                difficultyLevel = PointsEnum.Hard;
                break;
        }
    }
    public void CalculateRatingPoints()
    {
        float time = timeGO.GetComponent<Stopwatch>().GetCurrentTime();
        time = (int)time / 30;//время, через которое снимется очко рейтинга (в секундах)
        ratingPoints = (int)difficultyLevel - (int)time;
        if (ratingPoints <= ((int)difficultyLevel / 2))
        {
            ratingPoints = (int)difficultyLevel / 2;
        }
    }
}
