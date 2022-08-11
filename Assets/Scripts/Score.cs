using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action OnPointsGain;
    ScoreDataManager scoreDataManager;
    HighScoreEntry scoreEntry;

    int totalScore;
    //Take bonus points according to difficulty
    int point;
    int bonusPoint;

    public int TotalScore { get => totalScore;}
    public int Point { get => point; set => point = value; }
    public int BonusPoint { get => bonusPoint; set => bonusPoint = value; }

    void Awake()
    {
        totalScore = 0;
        point = 5;
        bonusPoint = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreDataManager = scoreDataManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreDataManager>();
        Answering.OnCorrectAnswer += AddScore; 
        Answering.OnBonusGain += AddBonusScore;
        Health.OnHealthDepleted += CheckScoreForSave;
        Mana.FullManaBonus += AddBonusScore;
    }

    void AddScore()
    {
        totalScore += point;
        OnPointsGain();
    }

    void AddBonusScore()
    {
        totalScore += bonusPoint;
        OnPointsGain();
    }

    void OnDisable()
    {
        Health.OnHealthDepleted -= CheckScoreForSave;
        Answering.OnCorrectAnswer -= AddScore;
        Answering.OnBonusGain -= AddBonusScore; 
        Mana.FullManaBonus -= AddBonusScore;
    }

    void CheckScoreForSave()
    {
        scoreEntry.score = totalScore;
        scoreEntry.magic = SelectedPref.Instance.SelectedCharacter.MagicType;
        scoreDataManager.AddNewScore(scoreEntry);
    }
}
