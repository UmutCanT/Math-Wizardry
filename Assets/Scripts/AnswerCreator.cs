using System.Collections;
using UnityEngine;

public static class AnswerCreator
{
    public static int[] AnswerGenerator(int correctAnswer, int[] answers)
    {
        for (int n = 0; n < answers.Length - 1; n++)
        {
            answers[n] = AnswerBounds(correctAnswer);
        }
        answers[3] = correctAnswer;
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

    static int AnswerBounds(int correctAnswer)
    {
        int number;

        if(correctAnswer <= 10)
        {
            do
            {
                number = Random.Range(0, 10);                
            } while (number == correctAnswer);
            return number;
        }
        else if (correctAnswer <= 100 && correctAnswer > 10)
        {
            do
            {
                number = Random.Range(correctAnswer - 10, correctAnswer + 20);
            } while (number == correctAnswer);
            return number;
        }
        else
        {
            int quotient = correctAnswer / 10;
            int reminder = correctAnswer % 10;           
            return (Random.Range(quotient + 1, quotient + 5) * 10) + reminder;
        }
    }
}
