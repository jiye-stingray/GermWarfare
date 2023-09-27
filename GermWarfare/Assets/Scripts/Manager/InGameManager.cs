﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    MapManager _mapManager => MapManager.Instance;

    public GermType _currentType = GermType.Blue;        // 파랑이 선공
    public bool _isFirstClick = true;                    //  첫 클릭
                                                         
    public MapTile _currentSelectTile = null;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Click(MapTile mapTile)
    {
        if(_isFirstClick)
        {
            FirstClick(mapTile);
        }
        else
        {
            SecondClick(mapTile);
        }
    }
    
    private void FirstClick(MapTile mapTile)
    {
        if (mapTile._germ._mapGermType != _currentType) return;     // 선택 타입이 현재 선택해야할 (currentType)과 다르면 return
        mapTile._germ.SelectGerm();

        _currentSelectTile = mapTile;
        _isFirstClick = false;
    }

    private void SecondClick(MapTile mapTile)
    {

        int disX = Math.Abs(Math.Abs(mapTile.x) - Math.Abs(_currentSelectTile.x));
        int disY = Math.Abs(Math.Abs(mapTile.y) - Math.Abs(_currentSelectTile.y));

        if (disX > 2 || disY > 2) return;       // x y 중 하나라도 2보다 거리가 멀리 있다면 return

        _currentSelectTile._germ.SetGerm(GermType.None);
        mapTile._germ.SetGerm(_currentType);
        mapTile._germ.Attack();


        _currentSelectTile = null;
        _isFirstClick = true;

        
    }
}
