using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using UnityEngine.UI;

public class CustomMapTile : MonoBehaviour
{
    private Image _image;
    private RectTransform _rectTrans;
    public int _tileTypeIndex = 0;

    [SerializeField] Color[] _colors;

    public GameObject _germObject = null;

    private void Awake()
    {
        _image= GetComponent<Image>();
        _rectTrans = GetComponent<RectTransform>();
    }


    public void SelectTileBtnClickEvent()
    {
        if(_germObject != null)
        {
            Color _color = _germObject.GetComponent<Image>().color;

            if (_color == Color.red)
                CustomMapInputUI.Instance._redGermList.Remove(_germObject);
            else if (_color == Color.blue)
                CustomMapInputUI.Instance._blueGermList.Remove(_germObject);

            Destroy(_germObject);
        }

        if(CurrentMapTileType.Instance._currentTileType == TileType.Germ) //현재 
        {
            if(_tileTypeIndex == 1)
            {

                if(_germObject != null)
                {
                    switch (_germObject.GetComponent<CustomGerm>()._germType)
                    {
                        case GermType.Red:
                            CustomMapInputUI.Instance._redGermList.Remove(_germObject); 
                            break;
                        case GermType.Blue:
                            CustomMapInputUI.Instance._blueGermList.Remove(_germObject);
                            break;
                        default:
                            break;
                    }
                    Destroy(_germObject);
                }

                //Germ 생성
                _germObject =  CustomMapInputUI.Instance.AddGerm(_rectTrans);

            }
        }
        else
        {
            _tileTypeIndex = (int)CurrentMapTileType.Instance._currentTileType;
            _image.color = _colors[_tileTypeIndex];

        }

    }
}
