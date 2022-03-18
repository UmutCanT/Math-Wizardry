using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answering : MonoBehaviour
{
    GameManager gameManager;

    public event Action onCorrectAnswer;
    public event Action onWrongAnswer;
    public event Action onAnswer;
    public event Action onBonusGain;

    int correctAnswerCounter;
    int requiredAmountForBonus = 1;

    void Awake()
    {
        correctAnswerCounter = 0;
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Essence"))
        {
            CheckAnswer(other);
            onAnswer();
        }
    }
    
    void CheckAnswer(Collider essence)
    {       
        if (essence.GetComponent<EssenceUI>().GetAnswer() == gameManager.CorrectAnswer)
        {
            Debug.Log("Correct ");
            onCorrectAnswer();
            correctAnswerCounter++;
            if (correctAnswerCounter >= requiredAmountForBonus)
            {
                onBonusGain();
                correctAnswerCounter = 0;
            }

        }
        else
        {
            Debug.Log("Wrong");
            onWrongAnswer();
        }
    }
}
