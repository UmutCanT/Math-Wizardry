using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Essence"))
        {
            if (other.GetComponent<EssenceUI>().GetAnswer() == gameManager.CorrectAnswer)
            {
                Answering.MissCorrect.Invoke();
            }
            else
            {
                other.gameObject.SetActive(false);
            }           
        }
    }
}
