using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionCreator
{ 
    public MathQuestion QuestionGenerator(MathQuestion mathQuestion)
    {
        MathOperations operation = (MathOperations)Random.Range(0, 4);
        Debug.Log("Hello2");
        return operation switch
        {
            MathOperations.Addition => Addition(mathQuestion),
            MathOperations.Substraction => Addition(mathQuestion),
            MathOperations.Multiplication => Addition(mathQuestion),
            MathOperations.Division => Addition(mathQuestion),
            _ => Addition(mathQuestion),
        };
    }

    MathQuestion Addition(MathQuestion mathQuestion)
    {
        mathQuestion.FirstNumber = Random.Range(0, 100);
        mathQuestion.SecondNumber = Random.Range(0, 100);
        mathQuestion.MathOperation = MathOperations.Addition;
        mathQuestion.CorrectAnswer = mathQuestion.FirstNumber + mathQuestion.SecondNumber;
        Debug.Log("Hello1");
        return mathQuestion;
    }
}
