using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action onPointsGain;

    int totalScore;
    //Take bonus points according to difficulty
    int point;

    public int TotalScore { get => totalScore; set => totalScore = value; }

    void Awake()
    {
        totalScore = 0;
        point = 5;
    }

    // Start is called before the first frame update
    void Start()
    {        
        GameObject.FindGameObjectWithTag("Player").GetComponent<Answering>().OnCorrectAnswer += AddScore;       
    }

    void AddScore()
    {
        totalScore += point;
        onPointsGain();
    }
}
