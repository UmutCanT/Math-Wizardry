using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreDataManager : MonoBehaviour
{
    static ScoreDataManager instance;
    string SavePath => $"{Application.persistentDataPath}/highscores.json";

    readonly int maxHighScoreEntries = 5;
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        Leaderboard savedScores = LoadHighScores();
        SaveHighScores(savedScores);
        DontDestroyOnLoad(gameObject);        
    }

    public void SaveHighScores(Leaderboard leaderboard)
    {
        using (StreamWriter stream = new StreamWriter(SavePath))
        {
            string json = JsonUtility.ToJson(leaderboard, true);
            stream.Write(json);
        }
    }

    public void AddNewScore(HighScoreEntry scoreEntry)
    {
        Leaderboard savedScores = LoadHighScores();

        bool scoreAdded = false;
        for (int i = 0; i < savedScores.highScores.Count; i++)
        {
            if (scoreEntry.score > savedScores.highScores[i].score)
            {
                savedScores.highScores.Insert(i, scoreEntry);
                scoreAdded = true;
                break;
            }
        }

        if (!scoreAdded && savedScores.highScores.Count < maxHighScoreEntries)
        {
            savedScores.highScores.Add(scoreEntry);
        }

        if (savedScores.highScores.Count > maxHighScoreEntries)
        {
            savedScores.highScores.RemoveRange(maxHighScoreEntries, savedScores.highScores.Count - maxHighScoreEntries);
        }

        SaveHighScores(savedScores);
    }

    public Leaderboard LoadHighScores()
    {
        if (!File.Exists(SavePath))
        {
            File.Create(SavePath).Dispose();
            return new Leaderboard();
        }

        using (StreamReader stream = new StreamReader(SavePath))
        {
            string json = stream.ReadToEnd();
            return JsonUtility.FromJson<Leaderboard>(json);
        }
    }
  
    [Serializable]
    public class Leaderboard
    {
        public List<HighScoreEntry> highScores = new List<HighScoreEntry>();       
    }
}
