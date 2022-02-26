using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    QuestionCreator questionCreator = new QuestionCreator();
    MathQuestion mathQuestion;
    List<MathQuestion> questions = new List<MathQuestion>();

    //Part for testing
    [SerializeField] Text problem;
    [SerializeField] Button answer1;
    [SerializeField] Button answer2;
    [SerializeField] Button answer3;
    [SerializeField] Button answer4;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AddingAndChecking), 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckResults()
    {
        foreach (var question in questions)
        {
            Debug.Log(question.FirstNumber + " " + question.MathOperation + " " + question.SecondNumber + "=" + question.CorrectAnswer);
        }
    }

    void AddingAndChecking()
    {
        AssignProblem(questionCreator.QuestionGenerator(mathQuestion));
    }

    void AssignProblem(MathQuestion question)
    {
        problem.text = string.Format("{0} {1} {2}", question.FirstNumber, OperationDecider(question.MathOperation), question.SecondNumber);
    }

    string OperationDecider(MathOperations operation)
    {
        return operation switch
        {
            MathOperations.Addition => "+",
            MathOperations.Substraction => "-",
            MathOperations.Multiplication => "*",
            MathOperations.Division => "/",
            _ => default
        };
    }


    public void CheckAnswer(Text answer)
    {
        if (mathQuestion.CorrectAnswer == int.Parse(answer.text))
        {
            CorrectAnswer();
        }
        else
            WrongAnswer();
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong");
    }

    void CorrectAnswer()
    {
        Debug.Log("Correct");
    }
   
}
