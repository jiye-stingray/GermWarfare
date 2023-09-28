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
    [SerializeField] TileType _currentTileType = TileType.Map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EraserTileBtnClickEvent()
    {
        _currentTileType= TileType.None;
    }

    public void MapTileBtnClickEvent()
    {
        _currentTileType= TileType.Map;
    }

    public void ObstacleTileBtnClickEvent()
    {
        _currentTileType= TileType.Obstacle;
    }
}
