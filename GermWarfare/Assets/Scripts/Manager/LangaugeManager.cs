using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LangaugeManager : Singleton<LangaugeManager>
{
    public int _localIndex = 0;
    [SerializeField] Button _button;

    bool isChanging = false;

    private void Start()
    {
        StartCoroutine(LocaleChange(_localIndex));
    }

    public void LangauageChangeBtnClickEvent()
    {
        if (isChanging)
            return;

        int n = (_localIndex == 0) ? 1 : 0;
        StartCoroutine(LocaleChange(n));

    }

    IEnumerator LocaleChange(int index)
    {
        isChanging = true;
        _localIndex = index;

        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];

        isChanging = false;
    }
}

