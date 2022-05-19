using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] records;
    [SerializeField] TextMeshProUGUI[] magic;
    ScoreDataManager scoreDataManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreDataManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreDataManager>();
        ResetUI();
        UpdateUI();
    }

    void ResetUI()
    {
        foreach (var item in records)
        {
            item.text = "";
        }        
    }

    void UpdateUI()
    {
        int i = 0;
        foreach (HighScoreEntry item in scoreDataManager.LoadHighScores().highScores)
        {
            records[i].text = item.score.ToString();
            i++;
        }
    }
}
