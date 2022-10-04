using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySettings : MonoBehaviour
{
    readonly string dynamicDifPrefKey = "DynamicDif";
    [SerializeField] Toggle dynamicDifToggle;

    void Awake()
    {
        if (!PlayerPrefs.HasKey(dynamicDifPrefKey))
        {
            PlayerPrefs.SetInt(dynamicDifPrefKey, 1);
        }

        dynamicDifToggle.onValueChanged.AddListener(DynamicDifHandler);       
    }

    void Start()
    {
        CheckDynamicDifOption();
    }

    void CheckDynamicDifOption()
    {      
        if (PlayerPrefs.GetInt(dynamicDifPrefKey) == 1)
        {
            dynamicDifToggle.isOn = true;
            SelectedPref.Instance.DynamicDifficulty = true;
        }
        else
        {
            dynamicDifToggle.isOn = false;
            SelectedPref.Instance.DynamicDifficulty = false;
        }
    }

    void DynamicDifHandler(bool enableSettings)
    {
        SelectedPref.Instance.DynamicDifficulty = enableSettings;
        if (enableSettings)
        {
            PlayerPrefs.SetInt(dynamicDifPrefKey, 1);
        }
        else
        {
            PlayerPrefs.SetInt(dynamicDifPrefKey, 0);
        }
    }
}
