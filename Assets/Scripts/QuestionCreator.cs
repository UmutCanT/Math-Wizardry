using UnityEngine;

public static class QuestionCreator
{
    static readonly DynamicDifficulty difficulty;

    static QuestionCreator()
    {
        difficulty = GameObject.FindObjectOfType<DynamicDifficulty>();
    }

    public static MathQuestion QuestionGenerator(MathQuestion mathQuestion)
    {
        mathQuestion.MathOperation = difficulty.OperationRandomizer();
        mathQuestion.Answers = new int[] {0,0,0,0}; 
        return mathQuestion.MathOperation switch
        {
            MathOperations.Addition => Addition(mathQuestion),
            MathOperations.Substraction => Substraction(mathQuestion),
            MathOperations.Multiplication => Multiplication(mathQuestion),
            MathOperations.Division => Division(mathQuestion),
            _ => Addition(mathQuestion)
        };
    }

    static MathQuestion Addition(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = difficulty.QuestionNumberRange(true);
        mathQuestion.SecondNumber = difficulty.QuestionNumberRange(true);
        mathQuestion.CorrectAnswer = mathQuestion.FirstNumber + mathQuestion.SecondNumber;
        Debug.Log(mathQuestion.FirstNumber + " " + mathQuestion.SecondNumber);
        return mathQuestion;
    }

    static MathQuestion Substraction(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = difficulty.QuestionNumberRange(true);
        mathQuestion.SecondNumber = difficulty.QuestionNumberRange(true);
        if (mathQuestion.FirstNumber >= mathQuestion.SecondNumber)
        {
            mathQuestion.CorrectAnswer = mathQuestion.FirstNumber - mathQuestion.SecondNumber;
        }else
            mathQuestion.CorrectAnswer = mathQuestion.SecondNumber - mathQuestion.FirstNumber;
        Debug.Log(mathQuestion.FirstNumber + " " + mathQuestion.SecondNumber);
        return mathQuestion;
    }

    static MathQuestion Multiplication(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = difficulty.QuestionNumberRange(false);
        mathQuestion.SecondNumber = difficulty.QuestionNumberRange(false);
        mathQuestion.CorrectAnswer = mathQuestion.FirstNumber * mathQuestion.SecondNumber;
        Debug.Log(mathQuestion.FirstNumber + " " + mathQuestion.SecondNumber);
        return mathQuestion;
    }

    static MathQuestion Division(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = difficulty.QuestionNumberRange(true);
        mathQuestion.SecondNumber = difficulty.QuestionNumberRange(false);
        mathQuestion.CorrectAnswer = mathQuestion.FirstNumber / mathQuestion.SecondNumber;
        Debug.Log(mathQuestion.FirstNumber + " " + mathQuestion.SecondNumber);
        return mathQuestion;
    }   
}
