using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None,
    Map,
    Obstacle
}

public class CustomMapInputUI : MonoBehaviour
{
    public TileType _currentTileType = TileType.Map;

    int[] _selectImgTransY = new int[] { 106, -29, -162 };
    [SerializeField] RectTransform _selectImg;

    int[,] _mapIndex = new int[10,10];

    [Header("MapInputUI")]
    [SerializeField] GameObject _tileBtnPrefab;
    [SerializeField] GameObject _InputMapBtnPanelObj;

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
        for (int i = 0; i < 99; i++)
        {
            GameObject go = Instantiate(_tileBtnPrefab, transform.position, Quaternion.identity);
            go.transform.parent = _InputMapBtnPanelObj.transform;
        }
    }

    public void EraserTileBtnClickEvent()
    {
        _currentTileType= TileType.None;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[1]);
    }

    public void MapTileBtnClickEvent()
    {
        _currentTileType= TileType.Map;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[0]);
    }

    public void ObstacleTileBtnClickEvent()
    {
        _currentTileType= TileType.Obstacle;
        _selectImg.anchoredPosition = new Vector2(_selectImg.anchoredPosition.x, _selectImgTransY[2]);
    }

    public void StartBtnClick()
    {
        GameManager.Instance._mapIndex = _mapIndex;
    }
}
