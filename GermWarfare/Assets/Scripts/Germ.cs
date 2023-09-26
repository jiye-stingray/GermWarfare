using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    public GermType _mapGermType;          // 현재 map에 type 상태
    [SerializeField] private SpriteRenderer _germRender;
    [SerializeField] GameObject _selectImgObj;

    public void SetGerm(GermType type)
    {
        _mapGermType = type;

        Color c = new Color();

        switch (type)
        {
            case GermType.None:
                c = new Color(1, 1, 1, 0);
                break;
            case GermType.Red:
                c = Color.red;
                break;
            case GermType.Blue:
                c = Color.blue;
                break;
            default:
                break;
        }

        _germRender.color = c;
    }

    /// <summary>
    /// 세균이 선택되었을 때 
    /// 첫번째 클릭시
    /// </summary>
    public void SelectGerm()
    {
        if (InGameManager.Instance._currentType == GermType.None) return;
        _selectImgObj.SetActive(true);
    }
}
