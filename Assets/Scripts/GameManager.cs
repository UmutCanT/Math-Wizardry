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
    [SerializeField] Button[] answers = new Button[4];
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

    public void AssignAnswers(Button[] essences, int[] answers)//Change Button to Essence type later
    {
        answerCreator.AnswerShuffle(answers);
        for (int n = 0; n < essences.Length; n++)
        {
            essences[n].GetComponentInChildren<Text>().text = answers[n].ToString();
        }
    }

    void AssignProblem(MathQuestion question)
    {
        problem.text = string.Format("{0} {1} {2}", question.FirstNumber, OperationDecider(question.MathOperation), question.SecondNumber);
        AssignAnswers(answers, answerCreator.AnswerGenerator(question.CorrectAnswer, question.Answers));
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
