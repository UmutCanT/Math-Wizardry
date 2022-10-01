using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSettings : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Dropdown localeSelection;
    readonly string localeKey = "localeKey";
    bool isCoroutineActive;

    public void LocaleInit()
    {
        SelectedPref.Instance.SelectedLocale = PlayerPrefs.GetInt(localeKey, 0);
        localeSelection.value = SelectedPref.Instance.SelectedLocale;
        ChangLocale(SelectedPref.Instance.SelectedLocale);
        localeSelection.onValueChanged.AddListener(ChangLocale);
    }

    public void ChangLocale(int value)
    {
        Debug.Log("ChangeLocale " + value);
        if (isCoroutineActive)
            return;
        StartCoroutine(SetLocal(value));
    }

    IEnumerator SetLocal(int localeId)
    {
        isCoroutineActive = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        PlayerPrefs.SetInt(localeKey, localeId);
        isCoroutineActive = false;
    }
}
