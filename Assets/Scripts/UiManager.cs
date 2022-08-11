using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI questionText;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject questionUI;
    [SerializeField] GameObject pauseButton;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
        {
            if (!gameOverPanel.activeInHierarchy)
            {
                Pause();
            }
        }               
    }

    public void ShowUI()
    {
        playerUI.SetActive(true);
        questionUI.SetActive(true);
        pauseButton.SetActive(true);
    }

    public void HideUI()
    {
        playerUI.SetActive(false);
        questionUI.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void Pause()
    {
        AudioManager.Instance.PlaySound(SoundType.BackButton);
        pausePanel.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().CanMove = false;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().CanMove = true;
        AudioManager.Instance.PlaySound(SoundType.BackButton);
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
        AudioManager.Instance.PlaySound(SoundType.BackButton);
        Time.timeScale = 1f;
        LoadingManager.Instance.LoadSelectedScene("MainMenu");       
    }

    public void SetQuestionText(string text)
    {
        questionText.text = text;
    }

    public void Restart()
    {
        AudioManager.Instance.PlaySound(SoundType.PlayButton);
        Time.timeScale = 1f;
        LoadingManager.Instance.LoadSelectedScene("EssenceCollector");       
    }
}
