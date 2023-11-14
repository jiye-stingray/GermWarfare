using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public List<GameObject> _redGermList = new List<GameObject>();
    public List<GameObject> _blueGermList = new List<GameObject>();

    [SerializeField] TMP_Text _warningText;

    void Start()
    {
        InitBtn();
    }

    private void OnEnable()
    {
        _warningText.gameObject.SetActive(false);
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
                go.GetComponent<RectTransform>().localScale = Vector3.one;
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
        if (_redGermList.Count < 1 || _blueGermList.Count < 1)
        {
            _warningText.gameObject.SetActive(true);
            return;
        }

        GameManager.Instance._addGermList.Clear();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _mapIndex[j, i] = _customMapTilesList[j,i]._tileTypeIndex;

                if (_customMapTilesList[j,i]._germObject != null)
                {
                    GermType germType = (_customMapTilesList[j, i]._germObject.GetComponent<Image>().color == Color.blue) ? GermType.Blue : GermType.Red;
                    GameManager.Instance._addGermList.Add(Tuple.Create(j, i, germType));
                }
            }
        }

        GameManager.Instance._mapIndex = _mapIndex;
        GameManager.Instance.LoadInGameScene();

    }


    public GameObject AddGerm(RectTransform trans)
    {
        GameObject g = Instantiate(_germImgPrefab, transform.position, Quaternion.identity);
        g.transform.SetParent(trans);
        g.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        g.GetComponent<RectTransform>().localScale = Vector2.one;

        Image img = g.GetComponent<Image>();

        switch (currentMapTileType._currentGermType)
        {
            case GermType.Red:
                if(_redGermList.Count >= 2)
                {
                    GameObject go = _redGermList[0];
                    _redGermList.RemoveAt(0);
                    Destroy(go);
                }
                img.color = Color.red;
                _redGermList.Add(g);
                break;

            case GermType.Blue:
                if (_blueGermList.Count >= 2)
                {
                    GameObject go = _blueGermList[0];
                    _blueGermList.RemoveAt(0);
                    Destroy(go);
                }
                img.color = Color.blue;
                _blueGermList.Add(g);
                break;

            default:
                break;
        }

        return g;
    }
}
