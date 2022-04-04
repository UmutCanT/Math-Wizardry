using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Score score;

    private void Start()
    {
        ScoreUIUpdate();
        score.OnPointsGain += ScoreUIUpdate;
    }

    void ScoreUIUpdate()
    {
        scoreText.text = score.TotalScore.ToString();
    }
}
