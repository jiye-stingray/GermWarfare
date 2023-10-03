using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CustomMapInputUI : MonoBehaviour
{
    CurrentMapTileType currentMapTileType => CurrentMapTileType.Instance;

    int[] _selectImgTransY = new int[] { 106, -29, -162 };
    [SerializeField] RectTransform _selectImg;

    [SerializeField] int[,] _mapIndex = new int[10,10];

    [Header("MapInputUI")]
    [SerializeField] GameObject _tileBtnPrefab;
    [SerializeField] GameObject _InputMapBtnPanelObj;
    [SerializeField] private CustomMapTile[,] _customMapTilesList = new CustomMapTile[10,10];

    void Start()
    {
        InitBtn();
    }
    private void InitBtn()
    {

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject go = Instantiate(_tileBtnPrefab, transform.position, Quaternion.identity);
                _customMapTilesList[j,i] = go.GetComponent<CustomMapTile>();
                go.GetComponent<RectTransform>().SetParent(_InputMapBtnPanelObj.GetComponent<RectTransform>());
            }
        }
    }

    public void EraserTileBtnClickEvent()
    {
        currentMapTileType._currentTileType= TileType.None;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[1]);
    }

    public void MapTileBtnClickEvent()
    {
        currentMapTileType._currentTileType = TileType.Map;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[0]);
    }

    public void ObstacleTileBtnClickEvent()
    {
        currentMapTileType._currentTileType= TileType.Obstacle;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[2]);
    }

    public void StartBtnClickEvent()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _mapIndex[j, i] = _customMapTilesList[j,i]._tileTypeIndex;
            }
        }

        GameManager.Instance._mapIndex = _mapIndex;
        SceneManager.LoadScene("InGameScene");

    }
}
