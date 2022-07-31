using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] Score score;
    [SerializeField] TMPro.TextMeshProUGUI gameOverScoreText;

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
        gameOverScoreText.text = string.Format("Score: {0}", score.TotalScore);
    }

    void OnDisable()
    {
        score.OnPointsGain -= ScoreUIUpdate;
        Health.OnHealthDepleted -= GameOverScoreUpdate;
    }
}
