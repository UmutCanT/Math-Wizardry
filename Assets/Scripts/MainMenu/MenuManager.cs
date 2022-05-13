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

    void Start()
    {
        HidePanels();
    }

    void Update()
    {
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        QuitPanelBehaviour();
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitPanelBehaviour();
        }
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

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
