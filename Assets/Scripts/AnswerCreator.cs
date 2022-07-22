using System.Collections;
using UnityEngine;

public static class AnswerCreator
{
    public static int[] AnswerGenerator(int correctAnswer, int[] answers)
    {
        answers[0] = correctAnswer;
        for (int n = 1; n < answers.Length; n++)
        {
            answers[n] = AnswerBounds(correctAnswer, answers);
        }      
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

    static int AnswerBounds(int correctAnswer, int[] answers)
    {
        int number;

        if(correctAnswer <= 10)
        {
            do
            {
                number = Random.Range(0, 10);                
            } while (CheckUniqueness(number, answers));
            return number;
        }
        else if (correctAnswer <= 100 && correctAnswer > 10)
        {
            do
            {
                number = Random.Range(correctAnswer - 10, correctAnswer + 15);
            } while (CheckUniqueness(number, answers));
            return number;
        }
        else
        {
            int quotient = correctAnswer / 10;
            int reminder = correctAnswer % 10;
            do
            {
                number = (Random.Range(quotient - 5, quotient + 5) * 10) + reminder;
            } while (CheckUniqueness(number, answers));
            return number;
        }
    }

    static bool CheckUniqueness(int number, int[] answers)
    {
        for (int n = 0; n < answers.Length; n++)
        {
            if(answers[n] == number)
            {
                return true;
            }
        }
        return false;
    }
}
