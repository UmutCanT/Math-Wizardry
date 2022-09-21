using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSettings : MonoBehaviour
{
    bool isCoroutineActive = true;

    public void ChangLocale(int localeId)
    {
        if (isCoroutineActive == true)
            return;
        StartCoroutine(SetLocal(localeId));
    }

    IEnumerator SetLocal(int localeId)
    {
        isCoroutineActive = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        isCoroutineActive = false;
    }
}
