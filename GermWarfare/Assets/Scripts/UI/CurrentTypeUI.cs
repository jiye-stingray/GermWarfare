using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTypeUI : MonoBehaviour
{
    [SerializeField] private Image[] _currentTypeImg;

    void Update()
    {
        for (int i = 0; i < _currentTypeImg.Length; i++)
        {
            _currentTypeImg[i].color = (InGameManager.Instance._currentType == GermType.Blue) ? Color.blue : Color.red;
        }
    }
}
