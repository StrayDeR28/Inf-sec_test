using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountRatingPoints : MonoBehaviour
{
    [SerializeField] private GameObject timeGO;
    [SerializeField] private int ratingPoints;
    [SerializeField] private PointsEnum difficultyLevel = PointsEnum.Easy;

    [SerializeField] private enum PointsEnum {Easy = 10, Medium = 20, Hard = 40};//макс значение очков рейтинга за уровень
    private void Awake()
    {
        float time = timeGO.GetComponent<Stopwatch>().GetCurrentTime();
        time = (int)time/30;//время, через которое снимется очко рейтинга (в секундах)
        ratingPoints = (int)difficultyLevel -(int)time;
        if(ratingPoints <= ((int)difficultyLevel / 2))
        {
            ratingPoints = (int)difficultyLevel / 2;
        }
    }
    public int GetRatingPoints()//Это передать на сервер
    {
        return ratingPoints;
    }
}
