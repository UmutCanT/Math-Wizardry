using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    QuestionCreator questionCreator = new QuestionCreator();
    AnswerCreator answerCreator = new AnswerCreator();
    MathQuestion mathQuestion;

    //Part for testing
    [SerializeField] Text problem;
    [SerializeField] Button answer1;
    [SerializeField] Button answer2;
    [SerializeField] Button answer3;
    [SerializeField] Button answer4;
    int correctAnswer;

    // Start is called before the first frame update
    void Start()
    {
        SetQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetQuestion()
    {
        AssignProblem(questionCreator.QuestionGenerator(mathQuestion));
    }

    private void AssignAnswer(Button a, Button b, Button c, Button d, int correctAnswer)
    {
        a.GetComponentInChildren<Text>().text = answerCreator.RandomAnswerGenerator(correctAnswer, 1).ToString();
        b.GetComponentInChildren<Text>().text = answerCreator.RandomAnswerGenerator(correctAnswer, 2).ToString();
        c.GetComponentInChildren<Text>().text = answerCreator.RandomAnswerGenerator(correctAnswer, 3).ToString();
        d.GetComponentInChildren<Text>().text = answerCreator.RandomAnswerGenerator(correctAnswer, 4).ToString();
    }

    void AssignProblem(MathQuestion question)
    {
        problem.text = string.Format("{0} {1} {2}", question.FirstNumber, OperationDecider(question.MathOperation), question.SecondNumber);
        AssignAnswer(answer1, answer2, answer3, answer4 ,question.CorrectAnswer);
        correctAnswer = question.CorrectAnswer;
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
        if (correctAnswer == int.Parse(answer.text))
        {
            CorrectAnswer();
        }
        else
            WrongAnswer();
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong");
        SetQuestion();
    }

    void CorrectAnswer()
    {
        Debug.Log("Correct");
        SetQuestion();
    }
   
}
