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
    //[SerializeField] private List<CustomMapTile> _customMapTilesList = new List<CustomMapTile>();
    [SerializeField] private CustomMapTile[,] _customMapTilesList = new CustomMapTile[10,10];

    // Start is called before the first frame update
    void Start()
    {
        InitBtn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void InitBtn()
    {
        /*  for (int i = 0; i < 100; i++)
          {
              GameObject go = Instantiate(_tileBtnPrefab, transform.position, Quaternion.identity);
              _customMapTilesList.Add(go.GetComponent<CustomMapTile>());
              go.transform.parent = _InputMapBtnPanelObj.transform;
          }*/

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject go = Instantiate(_tileBtnPrefab, transform.position, Quaternion.identity);
                _customMapTilesList[i,j] = go.GetComponent<CustomMapTile>();
                go.transform.parent = _InputMapBtnPanelObj.transform;
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
        int cnt = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _mapIndex[i, j] = _customMapTilesList[i,j]._tileTypeIndex;
            }
        }

        GameManager.Instance._mapIndex = _mapIndex;
        SceneManager.LoadScene("InGameScene");

    }
}
