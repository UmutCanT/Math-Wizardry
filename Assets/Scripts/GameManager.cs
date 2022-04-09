using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MathQuestion mathQuestion;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Character character;

    //Part for testing
    [SerializeField] Text problem;
    int correctAnswer;

    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

    void Awake()
    {
        PlayerSpawn();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ScreenSize.instance.Height + " + " + ScreenSize.instance.Width);
        for (int i = 0; i < 4; i++)
        {
            EssenceActivation(i);
        }
        SetQuestion();
    }

    //Later use with character select system
    void PlayerSpawn()
    {
        GameObject spawnedPlayer = Instantiate(playerPrefab, new Vector3(0, -2, 0), Quaternion.identity) as GameObject;
        Answering.OnAnswer += SetQuestion;
        spawnedPlayer.GetComponent<Health>().CurrentHealth = character.TotalHealth;
        spawnedPlayer.GetComponent<Player>().IntializeAbility(character.Abilites[0]);
    }

    void EssenceDeactivation()
    {
        foreach (var essence in EssencePool.SharedInstance.Essences)
        {
            essence.SetActive(false);
        }
    }

    void EssenceActivation(int i)
    {
        GameObject essence = EssencePool.SharedInstance.GetEssences();
        if (essence != null)
        {              
            essence.transform.rotation = Quaternion.identity;
            essence.SetActive(true);
        }
    }

    void SetQuestion()
    {
        EssenceDeactivation();
        for (int i = 0; i < 4; i++)
        {
            EssenceActivation(i);
            //EssenceReposition(i);
        }
        AssignProblem(QuestionCreator.QuestionGenerator(mathQuestion));
    }

    void AssignProblem(MathQuestion question)
    {
        //Later Put-in UI Manager
        problem.text = QuestionUI.AssignQuestion(question);
        QuestionUI.AssignAnswers(EssencePool.SharedInstance.Essences, AnswerCreator.AnswerGenerator(question.CorrectAnswer, question.Answers));
        CorrectAnswer = question.CorrectAnswer;
    }
}
