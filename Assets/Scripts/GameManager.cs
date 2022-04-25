using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MathQuestion mathQuestion;
    Character character;

    [SerializeField] Text questionText;
    [SerializeField] DynamicDifficulty difficulty;

    Vector3 playerSpawnPos = new Vector3(0, -2, 0);

    int correctAnswer;
    int essenceCount = 4;

    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

    void Awake()
    {
        PlayerSpawn();
    }

    // Start is called before the first frame update
    void Start()
    {
        EssenceActivation();
        SetQuestion();
    }

    //Later use with character select system
    void PlayerSpawn()
    {
        character = SelectedPref.Instance.SelectedCharacter;
        GameObject spawnedPlayer = Instantiate(character.PlayerPrefab, playerSpawnPos, Quaternion.identity) as GameObject;
        Answering.OnAnswer += SetQuestion;
        spawnedPlayer.GetComponent<Health>().CurrentHealth = character.TotalHealth;
        spawnedPlayer.GetComponent<Health>().OnHealthDepleted += GameOver;
        spawnedPlayer.GetComponent<Player>().IntializeAbility(character.Abilites[0]);
    }

    void EssenceDeactivation()
    {
        foreach (var essence in EssencePool.SharedInstance.Essences)
        {
            essence.SetActive(false);
        }
    }

    void EssenceActivation()
    {
        for (int i = 0; i < essenceCount; i++)
        {
            GameObject essence = EssencePool.SharedInstance.GetEssences();
            if (essence != null)
            {
                essence.transform.rotation = Quaternion.identity;
                essence.SetActive(true);
            }
        }      
    }

    void SetQuestion()
    {
        EssenceDeactivation();
        EssenceActivation();
        AssignQuestion(QuestionCreator.QuestionGenerator(mathQuestion));
    }

    void AssignQuestion(MathQuestion question)
    {
        //Later Put-in UI Manager
        questionText.text = QuestionUI.AssignQuestion(question);
        QuestionUI.AssignAnswers(EssencePool.SharedInstance.Essences, AnswerCreator.AnswerGenerator(question.CorrectAnswer, question.Answers));
        CorrectAnswer = question.CorrectAnswer;
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        EssenceDeactivation();
        Answering.OnAnswer -= SetQuestion;
        questionText.text = "";
    }
}
