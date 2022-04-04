using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Essence"))
        {
            if (other.GetComponent<EssenceUI>().GetAnswer() == gameManager.CorrectAnswer)
            {
                Answering.MissCorrect.Invoke();
            }
            other.gameObject.SetActive(false);
        }
    }
}
