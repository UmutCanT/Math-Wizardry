using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    MathQuestion mathQuestion;
    Character character;
    State currentState;
    GameObject spawnedPlayer;

    //[SerializeField] Text questionText;
    [SerializeField] DynamicDifficulty difficulty;
    [SerializeField] UiManager uiManager;

    Vector3 playerSpawnPos = new Vector3(0, -2, 0);

    int correctAnswer;
    readonly int essenceCount = 4;

    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

    void Awake()
    {
        uiManager.GameStart();
        PlayerSpawn();
        difficulty.OperationRandomizerCreator();
        currentState = new Easy(difficulty);        
        currentState.Process();
    }

    // Start is called before the first frame update
    void Start()
    {
        EssenceActivation();
        SetQuestion();
    }

    void OnEnable()
    {
        Answering.OnAnswer += SetQuestion;
        Answering.OnProgress += UpdateDifficultyProgress;
        Health.OnRegress += UpdateDifficultyRegress;
        Health.OnHealthDepleted += GameOver;
    }

    void OnDisable()
    {        
        Answering.OnProgress -= UpdateDifficultyProgress;
        Health.OnRegress -= UpdateDifficultyRegress;
        Health.OnHealthDepleted -= GameOver;
    }

    //Later use with character select system
    void PlayerSpawn()
    {
        character = SelectedPref.Instance.SelectedCharacter;
        spawnedPlayer = Instantiate(character.PlayerPrefab, playerSpawnPos, Quaternion.identity) as GameObject;       
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
        uiManager.SetQuestionText(QuestionUI.AssignQuestion(question));
        QuestionUI.AssignAnswers(EssencePool.SharedInstance.Essences, AnswerCreator.AnswerGenerator(question.CorrectAnswer, question.Answers));
        CorrectAnswer = question.CorrectAnswer;
    }

    void UpdateDifficultyProgress()
    {
        currentState = currentState.Progress();
        currentState.Process();
    }

    void UpdateDifficultyRegress()
    {
        currentState = currentState.Regress();
        currentState.Process();
    }

    void GameOver()
    {
        Answering.OnAnswer -= SetQuestion;
        Debug.Log("Game Over");
        EssenceDeactivation();       
        uiManager.GameOver();
    }
}
