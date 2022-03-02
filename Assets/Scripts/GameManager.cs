using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MathQuestion mathQuestion;

    //Part for testing
    [SerializeField] Text problem;
    [SerializeField] Button[] answers = new Button[4];
    int correctAnswer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            AssignEssences(i);
        }
        SetQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AssignEssences(int i)
    {
        GameObject essence = EssencePool.SharedInstance.GetEssences();
        if (essence != null)
        {
            essence.transform.position = Vector3.up * i;
            essence.transform.rotation = Quaternion.identity;
            essence.SetActive(true);
        }

    }

    void SetQuestion()
    {

        AssignProblem(QuestionCreator.QuestionGenerator(mathQuestion));
    }

    public void AssignAnswers(Button[] essences, int[] answers)//Change Button to Essence type later
    {
        AnswerCreator.AnswerShuffle(answers);
        for (int n = 0; n < essences.Length; n++)
        {
            essences[n].GetComponentInChildren<Text>().text = answers[n].ToString();
        }
    }

    void AssignProblem(MathQuestion question)
    {
        //Later Put-in UI Manager
        problem.text = string.Format("{0} {1} {2}", question.FirstNumber, OperationDecider(question.MathOperation), question.SecondNumber);
        AssignAnswers(answers, AnswerCreator.AnswerGenerator(question.CorrectAnswer, question.Answers));
        correctAnswer = question.CorrectAnswer;
    }

    //Later Put-in UI Manager
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
