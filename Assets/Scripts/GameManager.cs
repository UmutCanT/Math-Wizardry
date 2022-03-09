using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MathQuestion mathQuestion;
    [SerializeField] GameObject playerPrefab;

    //Part for testing
    [SerializeField] Text problem;
    [SerializeField] Button[] answers = new Button[4];
    int correctAnswer;

    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, new Vector3(0, -2, 0), Quaternion.identity).GetComponent<Answering>().onCorrectAnswer += SetQuestion; 
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
            essence.transform.position = EssencePosition(i);
            essence.transform.rotation = Quaternion.identity;
            essence.SetActive(true);
        }
    }
    //For test
    Vector3 EssencePosition(int i)
    {
        return i switch
        {
            0 => new Vector3(-2, 5, 0),
            1 => new Vector3(-0.75f, 5, 0),
            2 => new Vector3(0.75f, 5, 0),
            3 => new Vector3(2, 5, 0),
            _ => default,
        };
    }

    void SetQuestion()
    {
        AssignProblem(QuestionCreator.QuestionGenerator(mathQuestion));
    }

    public void AssignAnswers(Button[] essences, List<GameObject>essences2, int[] answers)//Change Button to Essence type later
    {
        AnswerCreator.AnswerShuffle(answers);
        for (int n = 0; n < essences.Length; n++)
        {
            essences[n].GetComponentInChildren<Text>().text = answers[n].ToString();
            essences2[n].GetComponent<EssenceUI>().SetAnswer(answers[n].ToString());
        }
    }

    void AssignProblem(MathQuestion question)
    {
        //Later Put-in UI Manager
        problem.text = QuestionUI.AssignQuestion(question);
        AssignAnswers(answers,EssencePool.SharedInstance.Essences, AnswerCreator.AnswerGenerator(question.CorrectAnswer, question.Answers));
        CorrectAnswer = question.CorrectAnswer;
    }

    void CheckAnswer(Text answer)
    {
        if (CorrectAnswer == int.Parse(answer.text))
        {
            OnCorrectAnswer();
        }
        else
            OnWrongAnswer();
    }

    void OnWrongAnswer()
    {
        Debug.Log("Wrong");
        SetQuestion();
    }

    void OnCorrectAnswer()
    {
        Debug.Log("Correct");
        SetQuestion();
    }
   
}
