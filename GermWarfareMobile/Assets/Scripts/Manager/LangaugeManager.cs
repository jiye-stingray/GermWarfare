using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LangaugeManager : Singleton<LangaugeManager>
{
    GameManager gameManager => GameManager.Instance;

    bool isChanging = false;

    private void Start()
    {
        StartCoroutine(LangaugeChangeCor(gameManager._localIndex));
    }

    public void LangauageChangeBtnClickEvent()
    {
        if (isChanging)
            return;

        gameManager._localIndex = (gameManager._localIndex == 0) ? 1 : 0;
        StartCoroutine(LangaugeChangeCor(gameManager._localIndex));

    }

    public void LangaugeChange()
    {

        if (isChanging)
            return;
        StartCoroutine(LangaugeChangeCor(gameManager._localIndex));

    }

    IEnumerator LangaugeChangeCor(int index)
    {
        isChanging = true;

        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];

        isChanging = false;
    }
}

