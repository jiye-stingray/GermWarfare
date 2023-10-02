using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTypeUI : MonoBehaviour
{
    [SerializeField] private Image _currentTypeImg;

    void Update()
    {
        _currentTypeImg.color = (InGameManager.Instance._currentType == GermType.Blue) ? Color.blue : Color.red;
    }
}
