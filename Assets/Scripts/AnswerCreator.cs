using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCreator
{
    public int RandomAnswerGenerator(int correctAnswer, int choice)
    {
        return choice switch
        {
            1 => Random.Range(0, 100),
            2 => Random.Range(0, 100),
            3 => Random.Range(0, 100),
            4 => correctAnswer,
            _ => default
        };
    }
}
