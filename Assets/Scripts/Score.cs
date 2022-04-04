using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action OnPointsGain;

    int totalScore;
    //Take bonus points according to difficulty
    int point;
    int bonusPoint;

    public int TotalScore { get => totalScore; set => totalScore = value; }

    void Awake()
    {
        totalScore = 0;
        point = 5;
        bonusPoint = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Answering>().OnCorrectAnswer += AddScore; 
        GameObject.FindGameObjectWithTag("Player").GetComponent<Answering>().OnBonusGain += AddBonusScore;       
    }

    void AddScore()
    {
        totalScore += point;
        OnPointsGain();
    }

    void AddBonusScore()
    {
        totalScore += bonusPoint;
        OnPointsGain();
    }
}
