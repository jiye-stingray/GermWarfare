using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class CustomMapInputUI : Singleton<CustomMapInputUI>
{
    CurrentMapTileType currentMapTileType => CurrentMapTileType.Instance;

    int[] _selectImgTransY = new int[] { 194, 55, -79, -213 };
    [SerializeField] RectTransform _selectImg;

    [SerializeField] int[,] _mapIndex = new int[10,10];

    [Header("MapInputUI")]
    [SerializeField] GameObject _tileBtnPrefab;
    [SerializeField] GameObject _InputMapBtnPanelObj;
    [SerializeField] private CustomMapTile[,] _customMapTilesList = new CustomMapTile[10,10];


    [Header("SetGerm")]
    [SerializeField] Image _selectGermBtnImg;
    [SerializeField] GameObject _germImgPrefab;
    Stack<GameObject> _redGermStack = new Stack<GameObject>();
    Stack<GameObject> _blueGermStack = new Stack<GameObject>();


    void Start()
    {
        InitBtn();
    }
    private void InitBtn()
    {
        _selectGermBtnImg.color = Color.blue;

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
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[2]);
    }

    public void MapTileBtnClickEvent()
    {
        currentMapTileType._currentTileType = TileType.Map;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[1]);
    }

    public void ObstacleTileBtnClickEvent()
    {
        currentMapTileType._currentTileType= TileType.Obstacle;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[3]);
    }
    public void SelectGermTypeBtnClickEvent()
    {
        currentMapTileType._currentTileType = TileType.Germ;
        currentMapTileType._currentGermType = (currentMapTileType._currentGermType == GermType.Blue) ? GermType.Red : GermType.Blue;
        _selectGermBtnImg.color = (currentMapTileType._currentGermType == GermType.Blue) ? Color.blue : Color.red;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[0]);

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


    public void AddGerm(RectTransform trans)
    {

        GameObject g = Instantiate(_germImgPrefab, transform.position, Quaternion.identity);
        g.transform.SetParent(trans);
        g.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        Image img = g.GetComponent<Image>();

        switch (currentMapTileType._currentGermType)
        {
            case GermType.Red:
                img.color = Color.red;
                _redGermStack.Push(g);
                break;
            case GermType.Blue:
                img.color = Color.blue;
                _blueGermStack.Push(g);
                break;
            default:
                break;
        }
    }
}
