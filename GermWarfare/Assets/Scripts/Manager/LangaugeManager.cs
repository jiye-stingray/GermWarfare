using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LangaugeManager : Singleton<LangaugeManager>
{
    public int _localIndex = 0;

    public void UserLocalization(int index)
    {
        _localIndex = index;
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[index];
    }
  
}
