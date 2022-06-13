using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] Text questionText;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject scoreUI;
    [SerializeField] GameObject questionUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
        {          
            Pause();
        }
    }

    public void ShowUI()
    {
        playerUI.SetActive(true);
        scoreUI.SetActive(true);
        questionUI.SetActive(true);
    }

    public void HideUI()
    {
        playerUI.SetActive(false);
        scoreUI.SetActive(false);
        questionUI.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        HideUI();
    }

    public void GameStart()
    {
        ShowUI();
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetQuestionText(string text)
    {
        questionText.text = text;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EssenceCollector");
    }
}
