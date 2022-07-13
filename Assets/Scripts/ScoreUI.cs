using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] Score score;

    void Start()
    {
        ScoreUIUpdate();
        score.OnPointsGain += ScoreUIUpdate;
    }

    void ScoreUIUpdate()
    {
        scoreText.text = score.TotalScore.ToString();
    }

    void OnDisable()
    {
        score.OnPointsGain -= ScoreUIUpdate;
    }
}
