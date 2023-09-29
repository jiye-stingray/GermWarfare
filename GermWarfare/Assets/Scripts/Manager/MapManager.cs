﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private GameObject _map;
    [SerializeField] private GameObject _mapTilePrefab;
    [SerializeField] private GameObject _obstacleMapTilePrefab;     // 장애물 prefab
    [SerializeField] private GameObject _noneMapTilePrefab;        // 빈칸 prefab

    [Header("Map")]
    public int[,] _mapInt;
    public MapTile[,] _mapTiles;
    


    void Start()
    {
        InputMap();
    }

    /// <summary>
    /// Map의 2차원을 입력
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
        _mapTiles = new MapTile[_mapInt.GetLength(0),_mapInt.GetLength(1)];

        float xMapScale = _map.transform.localScale.x;
        float yMapScale = _map.transform.localScale.y;

        int minI = int.MaxValue;
        int maxI = int.MinValue;
        int minJ = int.MaxValue;
        int maxJ = int.MinValue;

        for (int i = 0; i < _mapInt.GetLength(0); i++)
        {
            for (int j = 0; j < _mapInt.GetLength(1); j++)
            {

                    GameObject m = null;
                    if (_mapInt[i,j] == 1)
                    {
                        minI = Math.Min(minI, i);
                        minJ = Math.Min(minJ, j);
                        maxI = Math.Max(maxI, i);
                        maxJ = Math.Max(maxJ, j);

                         m = Instantiate(_mapTilePrefab, transform.position, Quaternion.identity);
                    }
                    else if (_mapInt[i,j] == 2)
                        m = Instantiate(_obstacleMapTilePrefab, transform.position, Quaternion.identity);       // 장애물 생성
                    else if (_mapInt[i,j] == 0)
                        m = Instantiate(_noneMapTilePrefab,transform.position,Quaternion.identity);

                    m.transform.localScale = new Vector2(xMapScale / _mapInt.GetLength(0), yMapScale / _mapInt.GetLength(1));
                    m.transform.parent = _map.transform;
                    m.transform.localPosition = new Vector2(m.transform.localScale.x * i, -m.transform.localScale.y * j);

                    MapTile mapT = m.GetComponent<MapTile>();
                    mapT.x = i;
                    mapT.y = j;

                    _mapTiles[i, j] = mapT;

            }
        }

        Debug.Log(minI + " " + minJ + " " + maxI + " " + maxJ);

        // 시작 세균 추가 
        _mapTiles[minI, minJ].GetComponent<NormalMapTile>()._germ.SetGerm(GermType.Blue);
        _mapTiles[maxI, maxJ].GetComponent<NormalMapTile>()._germ.SetGerm(GermType.Blue);
        _mapTiles[minI, maxJ].GetComponent<NormalMapTile>()._germ.SetGerm(GermType.Red);
        _mapTiles[maxI, minJ].GetComponent<NormalMapTile>()._germ.SetGerm(GermType.Red);

    }


}
