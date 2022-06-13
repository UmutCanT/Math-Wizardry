using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject CharacterSelectionPanel;
    [SerializeField] GameObject CreditsPanel;
    [SerializeField] GameObject QuitPanel;
    [SerializeField] TMPro.TMP_Dropdown difSelection;
    readonly string difficultyKey = "dificultyKey";

    void Start()
    {
        LoadDifficultyValue();
        HidePanels();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitPanelBehaviour();
        }
#else
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitPanelBehaviour();
            }
        }
#endif
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("EssenceCollector");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadScoreScene()
    {
        SceneManager.LoadScene("ScoreBoard");
    }

    public void ShowCharacterSelectionPanel()
    {
        CharacterSelectionPanel.SetActive(true);
    }

    public void ShowCreditsPanel()
    {
        CreditsPanel.SetActive(true);
    }

    void HidePanels()
    {
        CharacterSelectionPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        QuitPanel.SetActive(false);
    }

    void QuitPanelBehaviour()
    {
        if (QuitPanel.activeInHierarchy)
        {
            QuitPanel.SetActive(false);
        }
        else
            QuitPanel.SetActive(true);
    }

    public void SetDifficulty()
    {
        SelectedPref.Instance.SelectedDifficulty = difSelection.value;
    }

    public void OnCharacterSelect(Character character)
    {
        SelectedPref.Instance.SelectedCharacter = character;
    }

    public void QuitGame()
    {
        SaveDifficultyValue();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void LoadDifficultyValue()
    {
        if (PlayerPrefs.HasKey(difficultyKey))
        {
            difSelection.value = PlayerPrefs.GetInt(difficultyKey);
        }
    }

    void SaveDifficultyValue()
    {
        PlayerPrefs.SetInt(difficultyKey, difSelection.value);
        PlayerPrefs.Save();
    }
}
