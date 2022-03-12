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
        Debug.Log(essence.GetComponent<EssenceUI>().GetAnswer() + " From Essence");
        Debug.Log(gameManager.CorrectAnswer + " From manager");
        if (essence.GetComponent<EssenceUI>().GetAnswer() == gameManager.CorrectAnswer)
        {
            Debug.Log("Correct " + essence.GetComponent<EssenceUI>().GetAnswer());
            onCorrectAnswer();
        }
        else
        {
            Debug.Log("Wrong");
            //onWrongAnswer();
        }
    }
}
