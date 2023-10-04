using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    GameManager _gameManager => GameManager.Instance;
    MapManager _mapManager => MapManager.Instance;

    public GermType _currentType = GermType.Blue;        // 파랑이 선공
    public bool _isFirstClick = true;                    //  첫 클릭
                                                         
    public NormalMapTile _currentSelectTile = null;

    private void Start()
    {
        _gameManager.ScoreBlue = 0;
        _gameManager.ScoreRed = 0;
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
        NormalMapTile normalMapTile = mapTile.GetComponent<NormalMapTile>();

        if (normalMapTile._germ._mapGermType != _currentType) return;     // 선택 타입이 현재 선택해야할 (currentType)과 다르면 return
        normalMapTile._germ.SelectGerm();

        _currentSelectTile = normalMapTile;
        _isFirstClick = false;
    }

    private void SecondClick(MapTile mapTile)
    {
        NormalMapTile normalMapTile = mapTile.GetComponent<NormalMapTile>();

        if (normalMapTile._germ._mapGermType != GermType.None)
        {
            _isFirstClick = true;       // 잘못 선택했을 때 다시 선택하게 
            _currentSelectTile._germ.SetGerm(_currentSelectTile._germ._mapGermType);
            return;     
        }


        int disX = Math.Abs(Math.Abs(mapTile.x) - Math.Abs(_currentSelectTile.x));
        int disY = Math.Abs(Math.Abs(mapTile.y) - Math.Abs(_currentSelectTile.y));

        if (disX > 2 || disY > 2) return;       // x y 중 하나라도 2보다 거리가 멀리 있다면 return

        _currentSelectTile._germ.SetGerm(GermType.None);
        normalMapTile._germ.SetGerm(_currentType);
        normalMapTile._germ.Attack();


        _currentSelectTile = null;
        _isFirstClick = true;

        GermMoveEnd();
    }

    private void GermMoveEnd()
    {
        ChangeAttak();
        GameManager.Instance.SetScore();

        for (int i = 0; i < _mapManager._mapTiles.GetLength(0); i++)
        {
            for (int j = 0; j < _mapManager._mapTiles.GetLength(1); j++)
            {
                if(_mapManager._mapTiles[i, j].TryGetComponent<NormalMapTile>(out NormalMapTile normalMapTile))
                {
                    // 현재 칸에 하나라도 빈칸이 있으면 모든 칸이 채워진것이 아니다. return
                    if (normalMapTile._germ._mapGermType == GermType.None) return;
                }

            }
        }

        //모든 칸에 세균이 다 채워졌을 때
        GameManager.Instance.GameOver(false);
    }

    /// <summary>
    /// 공격 전환
    /// </summary>
    private void ChangeAttak()
    {
        _currentType = (_currentType == GermType.Blue) ? GermType.Red : GermType.Blue;
    }

    public void SurrenderBtnClickEvent()
    {
        GameManager.Instance.GameOver(true);
    }
}
