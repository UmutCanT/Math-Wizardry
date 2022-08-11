using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    MathQuestion mathQuestion;
    Character character;
    State currentState;
    GameObject spawnedPlayer;
    
    [SerializeField] DynamicDifficulty difficulty;
    [SerializeField] UiManager uiManager;
    [SerializeField] MeterScript meterScript;

    Vector3 playerSpawnPos = new Vector3(0, -1.22f, 0);

    int correctAnswer;
    readonly int essenceCount = 4;

    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

    void Awake()
    {
        uiManager.GameStart();
        PlayerSpawn();
        difficulty.OperationRandomizerCreator();
        currentState = StartingDifficulty(SelectedPref.Instance.SelectedDifficulty);
        currentState.Process();       
        QuestionCreator.Initializer();
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
        Answering.OnAnswer -= SetQuestion;
        Answering.OnProgress -= UpdateDifficultyProgress;
        Health.OnRegress -= UpdateDifficultyRegress;
        Health.OnHealthDepleted -= GameOver;
    }

    State StartingDifficulty(int selectedDif)
    {
        return selectedDif switch
        {
            0 => new Easy(difficulty),
            1 => new Medium(difficulty),
            2 => new Hard(difficulty),
            _ => new Medium(difficulty)
        };
    }

    //Later use with character select system
    void PlayerSpawn()
    {
        character = SelectedPref.Instance.SelectedCharacter;
        meterScript.Initialize(character);
        spawnedPlayer = Instantiate(character.PlayerPrefab, playerSpawnPos, Quaternion.identity) as GameObject;       
        spawnedPlayer.GetComponent<Health>().MaxHealth = character.TotalHealth;
        spawnedPlayer.GetComponent<Mana>().TotalManaPool = character.TotalMana;
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
        EssenceDeactivation();       
        uiManager.GameOver();
    }
}
