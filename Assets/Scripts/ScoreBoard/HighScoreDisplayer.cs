using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HighScoreDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] records;
    [SerializeField] Image[] magicUI;
    [SerializeField] Sprite[] magicSprite;
    ScoreDataManager scoreDataManager;

    // Start is called before the first frame update
    void Start()
    {       
        scoreDataManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreDataManager>();
        ResetUI();
        UpdateUI();
        AudioManager.Instance.PlaySound(SoundType.MenuChange);
    }

    void ResetUI()
    {
        foreach (var item in records)
        {
            item.text = "";
        }
        
        foreach(var item in magicUI)
        {
            item.sprite = magicSprite[0];
        }
    }

    void UpdateUI()
    {
        int i = 0;
        foreach (HighScoreEntry item in scoreDataManager.LoadHighScores().highScores)
        {
            records[i].text = item.score.ToString();
            magicUI[i].sprite = SpriteDecider(item.magic);
            i++;
        }
    }

    public void BackToMain()
    {
        AudioManager.Instance.PlaySound(SoundType.BackButton);
        SceneManager.LoadScene("MainMenu");
    }

    Sprite SpriteDecider(string magic)
    {
        return magic switch
        {
            "Ice" => magicSprite[1],
            "Fire" => magicSprite[2],
            _ => magicSprite[0],
        };
    }
}
