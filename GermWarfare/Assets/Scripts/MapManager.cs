using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject _map;
    public GameObject _mapTilePrefab;
    MapTile[,] _mapTiles;

    int[] _mapScale = new int[] { 14, 10 };

    // Start is called before the first frame update
    void Start()
    {
        CreateMap(5, 5);        // 추후 입력 변경 
    }

    /// <summary>
    /// 정해진 크기에 맞춰 맵 생성
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void CreateMap(int x, int y)
    {
        _mapTiles = new MapTile[x, y];

        float xMapScale = _map.transform.localScale.x;
        float yMapScale = _map.transform.localScale.y;

        for (int i = 0; i < _mapTiles.GetLength(0); i++)
        {
            for (int j = 0; j < _mapTiles.GetLength(1); j++)
            {
                GameObject m =  Instantiate(_mapTilePrefab,transform.position, Quaternion.identity);
                m.transform.localScale = new Vector2(xMapScale / _mapTiles.GetLength(0), yMapScale/ _mapTiles.GetLength(1));
                m.transform.parent = _map.transform;
                m.transform.localPosition = new Vector2( m.transform.localScale.x * i, -m.transform.localScale.y *  j);

                MapTile mapT = m.GetComponent<MapTile>();
                mapT.x = i;
                mapT.y = j;
            }
        }
    }
}
