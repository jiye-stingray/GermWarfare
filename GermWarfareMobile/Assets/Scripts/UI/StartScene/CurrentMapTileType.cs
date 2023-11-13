using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None,
    Map,
    Obstacle,
    Germ
}
public class CurrentMapTileType : Singleton<CurrentMapTileType>
{
    public TileType _currentTileType = TileType.Map;
    public GermType _currentGermType = GermType.Blue;
}
