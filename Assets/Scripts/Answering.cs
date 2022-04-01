using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answering : MonoBehaviour
{
    GameManager gameManager;

    public event Action OnCorrectAnswer;
    public event Action OnWrongAnswer;
    public event Action OnAnswer;
    public event Action OnBonusGain;

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
            OnAnswer();
        }
    }
    
    void CheckAnswer(Collider essence)
    {       
        if (essence.GetComponent<EssenceUI>().GetAnswer() == gameManager.CorrectAnswer)
        {
            Debug.Log("Correct ");
            OnCorrectAnswer();
            correctAnswerCounter++;
            if (correctAnswerCounter >= requiredAmountForBonus)
            {
                OnBonusGain();
                correctAnswerCounter = 0;
            }

        }
        else
        {
            Debug.Log("Wrong");
            OnWrongAnswer();
        }
    }
}
