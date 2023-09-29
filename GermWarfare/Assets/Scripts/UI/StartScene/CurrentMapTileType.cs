using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None,
    Map,
    Obstacle
}
public class CurrentMapTileType : Singleton<CurrentMapTileType>
{
    public TileType _currentTileType = TileType.Map;
}
