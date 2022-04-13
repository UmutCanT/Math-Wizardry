using UnityEngine;

public static class QuestionCreator
{ 
    public static MathQuestion QuestionGenerator(MathQuestion mathQuestion)
    {
        MathOperations operation = (MathOperations)Random.Range(0, 4);
        mathQuestion.MathOperation = operation;
        mathQuestion.Answers = new int[] {0,0,0,0}; 
        return operation switch
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
        mathQuestion.FirstNumber = Random.Range(0, 100);
        mathQuestion.SecondNumber = Random.Range(0, 100);
        mathQuestion.CorrectAnswer = mathQuestion.FirstNumber + mathQuestion.SecondNumber;
        return mathQuestion;
    }

    static MathQuestion Substraction(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = Random.Range(0, 100);
        mathQuestion.SecondNumber = Random.Range(0, 100);
        if (mathQuestion.FirstNumber >= mathQuestion.SecondNumber)
        {
            mathQuestion.CorrectAnswer = mathQuestion.FirstNumber - mathQuestion.SecondNumber;
        }else
            mathQuestion.CorrectAnswer = mathQuestion.SecondNumber - mathQuestion.FirstNumber;
        return mathQuestion;
    }

    static MathQuestion Multiplication(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = Random.Range(0, 20);
        mathQuestion.SecondNumber = Random.Range(0, 50);
        mathQuestion.CorrectAnswer = mathQuestion.FirstNumber * mathQuestion.SecondNumber;
        return mathQuestion;
    }

    static MathQuestion Division(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = Random.Range(10, 100);
        mathQuestion.SecondNumber = Random.Range(1, 10);
        mathQuestion.CorrectAnswer = mathQuestion.FirstNumber / mathQuestion.SecondNumber;
        return mathQuestion;
    }
    
}
