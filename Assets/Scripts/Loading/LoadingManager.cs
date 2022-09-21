using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image bar;
    [SerializeField] TextMeshProUGUI loadingText;
    AsyncOperation operation;
   
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        loadingScreen.SetActive(false);        
    }

    public void LoadSelectedScene(string sceneName)
    {       
        UpdateUI(0);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            UpdateUI(operation.progress);
            yield return null;
        }

        UpdateUI(operation.progress);
        operation = null;
        loadingScreen.SetActive(false);
    }

    void UpdateUI(float progress)
    {
        bar.fillAmount = progress;
        loadingText.text = string.Format("{0}%",Mathf.RoundToInt(progress * 100f));
    }
}
