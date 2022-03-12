using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    //Take bonus points according to difficulty
    int point;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        point = 5;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Answering>().onCorrectAnswer += AddScore;       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
    }

    void AddScore()
    {
        score += point;
    }
}
