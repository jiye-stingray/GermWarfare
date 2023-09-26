using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapTileImageClick : MonoBehaviour , IPointerClickHandler
{
    MapTile _mapTile;

    private void Awake()
    {
        _mapTile = GetComponentInParent<MapTile>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InGameManager.Instance.Click(_mapTile);
    }
}
