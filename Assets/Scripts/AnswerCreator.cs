using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCreator
{
    public int[] AnswerGenerator(int correctAnswer, int[] answers)
    {
        for (int n = 0; n < answers.Length; n++)
        {
            answers[n] = Random.Range(0, 100);
        }
        answers[0] = correctAnswer;
        return answers;
    }

    public void AnswerShuffle(int[] answers)
    {    
        for (int n = 0; n < answers.Length; n++)
        {
            int tmp = answers[n];
            int r = Random.Range(n, answers.Length);
            answers[n] = answers[r];
            answers[r] = tmp;
        }
    }
}
