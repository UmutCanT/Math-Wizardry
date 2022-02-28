using System.Collections;
using UnityEngine;

//Merge with Question Creator ?
public static class AnswerCreator
{
    public static int[] AnswerGenerator(int correctAnswer, int[] answers)
    {
        for (int n = 0; n < answers.Length; n++)
        {
            answers[n] = Random.Range(0, 100);
        }
        answers[0] = correctAnswer;
        return answers;
    }

    public static void AnswerShuffle(int[] answers)
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
