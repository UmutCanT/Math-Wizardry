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
    int correctAnswer;

    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

    void Awake()
    {
        Instantiate(playerPrefab, new Vector3(0, -2, 0), Quaternion.identity).GetComponent<Answering>().onAnswer += SetQuestion;
    }

    // Start is called before the first frame update
    void Start()
    {       
        for (int i = 0; i < 4; i++)
        {
            EssenceActivation(i);
        }
        SetQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EssenceDeactivation()
    {
        foreach (var essence in EssencePool.SharedInstance.Essences)
        {
            essence.SetActive(false);
        }
    }

    void EssenceReposition(int i)
    {
        EssencePool.SharedInstance.Essences[i].transform.position = EssencePosition(i);
    }

    void EssenceActivation(int i)
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
        //EssenceDeactivation();
        for (int i = 0; i < 4; i++)
        {
            //EssenceActivation(i);
            EssenceReposition(i);
        }
        AssignProblem(QuestionCreator.QuestionGenerator(mathQuestion));
    }

    //public void AssignAnswers(List<GameObject>essences, int[] answers)
    //{
    //    AnswerCreator.AnswerShuffle(answers);
    //    for (int n = 0; n < essences.Count; n++)
    //    {            
    //        essences[n].GetComponent<EssenceUI>().SetAnswer(answers[n].ToString());
    //    }
    //}

    void AssignProblem(MathQuestion question)
    {
        //Later Put-in UI Manager
        problem.text = QuestionUI.AssignQuestion(question);
        QuestionUI.AssignAnswers(EssencePool.SharedInstance.Essences, AnswerCreator.AnswerGenerator(question.CorrectAnswer, question.Answers));
        CorrectAnswer = question.CorrectAnswer;
    }
}
