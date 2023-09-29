using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMapTile : MonoBehaviour
{
    private Image _image;
    public int _tileTypeIndex = 0;

    [SerializeField] Color[] _colors;

    private void Awake()
    {
        _image= GetComponent<Image>();
    }


    public void SelectTileBtnClickEvent()
    {
        _tileTypeIndex = (int)CurrentMapTileType.Instance._currentTileType;
        _image.color = _colors[_tileTypeIndex];
    }
}
