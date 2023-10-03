using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMapTile : MonoBehaviour
{
    private Image _image;
    private RectTransform _rectTrans;
    public int _tileTypeIndex = 0;

    [SerializeField] Color[] _colors;

    private void Awake()
    {
        _image= GetComponent<Image>();
        _rectTrans = GetComponent<RectTransform>();
    }


    public void SelectTileBtnClickEvent()
    {
        if(CurrentMapTileType.Instance._currentTileType == TileType.Germ) //현재 
        {
            if(_tileTypeIndex == 1)
            {
                //Germ 생성
                CustomMapInputUI.Instance.AddGerm(_rectTrans);
            }

        }
        else
        {
            _tileTypeIndex = (int)CurrentMapTileType.Instance._currentTileType;
            _image.color = _colors[_tileTypeIndex];

        }

    }
}
