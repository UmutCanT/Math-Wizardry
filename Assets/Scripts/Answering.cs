using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answering : MonoBehaviour
{
    GameManager gameManager;

    public static event Action OnCorrectAnswer;
    public static event Action OnWrongAnswer;
    public static event Action OnAnswer;
    public static event Action OnBonusGain;
    public delegate void OnMissCorrect();
    public static OnMissCorrect MissCorrect = () => { 
        OnWrongAnswer();
        OnAnswer();
    };

    int correctAnswerCounter;

    void Awake()
    {
        correctAnswerCounter = 0;
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Essence"))
        {
            CheckAnswer(other);
            OnAnswer();
        }
    }
    
    void CheckAnswer(Collider essence)
    {       
        if (essence.GetComponent<EssenceUI>().GetAnswer() == gameManager.CorrectAnswer)
        {
            Debug.Log("Correct");
            OnCorrectAnswer();
            correctAnswerCounter++;
            if (essence.GetComponent<Essence>().Status == Statuses.effected)
            {
                OnBonusGain();
            }

        }
        else
        {
            Debug.Log("Wrong");
            OnWrongAnswer();
        }
    }  
}
