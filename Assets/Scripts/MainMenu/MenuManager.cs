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
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject Tutorials;
    [SerializeField] TMPro.TMP_Dropdown difSelection;
    readonly string difficultyKey = "dificultyKey";
    readonly string tutorialKey = "tutorial";

    void Awake()
    {
        LoadDifficultyValue();
        difSelection.onValueChanged.AddListener(DiffChangeButtonSound);
        difSelection.onValueChanged.AddListener(SetDifficulty);
    }

    void Start()
    {
        SetDifficulty(difSelection.value);
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

    public void ShowTutorials()
    {
        if (!PlayerPrefs.HasKey(tutorialKey))
        {
            Tutorials.SetActive(true);
            PlayerPrefs.SetInt(tutorialKey, 1);
        }
    }

    public void PlayButtonSound()
    {
        AudioManager.Instance.PlaySound(SoundType.PlayButton);
    }

    public void DiffChangeButtonSound(int value)
    {
        AudioManager.Instance.PlaySound(SoundType.DiffChangeButton, 0.3f);
    }

    public void BackButtonSound()
    {
        AudioManager.Instance.PlaySound(SoundType.BackButton);
    }

    public void MenuChangeSound()
    {
        AudioManager.Instance.PlaySound(SoundType.MenuChange);
    }

    public void LoadGameScene()
    {
        LoadingManager.Instance.LoadSelectedScene("EssenceCollector");
    }

    public void LoadScoreScene()
    {
        LoadingManager.Instance.LoadSelectedScene("ScoreBoard");
    }

    void HidePanels()
    {
        Tutorials.SetActive(false);
        CharacterSelectionPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        QuitPanel.SetActive(false);
        SettingsPanel.SetActive(false);
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

    public void SetDifficulty(int value)
    {
        SelectedPref.Instance.SelectedDifficulty = value;
        PlayerPrefs.SetInt(difficultyKey, value);
    }

    public void OnCharacterSelect(Character character)
    {
        SelectedPref.Instance.SelectedCharacter = character;
    }

    public void QuitGame()
    {
        PlayerPrefs.Save();
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
        else
        {
            difSelection.value = 1;
        }
    }
}