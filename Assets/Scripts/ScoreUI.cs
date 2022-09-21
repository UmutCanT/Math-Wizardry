using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Score score;
    [SerializeField] TextMeshProUGUI gameOverScoreText;

    void Start()
    {
        ScoreUIUpdate();
        score.OnPointsGain += ScoreUIUpdate;
        Health.OnHealthDepleted += GameOverScoreUpdate;
    }

    void ScoreUIUpdate()
    {
        scoreText.text = score.TotalScore.ToString();
    }

    void GameOverScoreUpdate()
    {
        gameOverScoreText.text = string.Format("{0}", score.TotalScore);
    }

    void OnDisable()
    {
        score.OnPointsGain -= ScoreUIUpdate;
        Health.OnHealthDepleted -= GameOverScoreUpdate;
    }
}
