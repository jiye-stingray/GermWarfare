using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapManager : Singleton<MapManager>
{
    public GameObject _map;
    public GameObject _mapTilePrefab;

    [Header("Map")]
    public int[,] _mapInt;
    public MapTile[,] _mapTiles;


    public int _mapX = 5;
    public int _mapY = 5;



    void Start()
    {
        CreateMap();        // 추후 입력 변경 
    }

    /// <summary>
    /// Map의 2차원을 입력..?
    /// </summary>
    public void InputMap()
    {
        _mapInt = GameManager.Instance._mapIndex;
        CreateMap();
    }


    /// <summary>
    /// 정해진 크기에 맞춰 맵 생성
    /// </summary>
    private void CreateMap()
    {   

        float xMapScale = _map.transform.localScale.x;
        float yMapScale = _map.transform.localScale.y;

        for (int i = 0; i < _mapInt.GetLength(0); i++)
        {
            for (int j = 0; j < _mapInt.GetLength(1); j++)
            {
                if (_mapInt[i,j] == 1)
                {
                    GameObject m =  Instantiate(_mapTilePrefab,transform.position, Quaternion.identity);
                    m.transform.localScale = new Vector2(xMapScale / _mapInt.GetLength(0), yMapScale/ _mapInt.GetLength(1));
                    m.transform.parent = _map.transform;
                    m.transform.localPosition = new Vector2( m.transform.localScale.x * i, -m.transform.localScale.y *  j);

                    MapTile mapT = m.GetComponent<MapTile>();
                    mapT.x = i;
                    mapT.y = j;

                    _mapTiles[i, j] = mapT;
                }

            }
        }

        // 시작 세균 추가
        _mapTiles[0, 0]._germ.SetGerm(GermType.Blue);
        _mapTiles[_mapX - 1, _mapY - 1]._germ.SetGerm(GermType.Blue);
        _mapTiles[0, _mapY - 1]._germ.SetGerm(GermType.Red);
        _mapTiles[_mapX - 1, 0]._germ.SetGerm(GermType.Red);

    }


}
