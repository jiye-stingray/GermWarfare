using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    MapManager _mapManager => MapManager.Instance;

    public GermType _currentType = GermType.Blue;        // 파랑이 선공
    public bool _isFirstClick = true;                    //  첫 클릭                       

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
            SecondClick();
        }
    }
    
    private void FirstClick(MapTile mapTile)
    {
        if (mapTile._germ._mapGermType != _currentType) return;     // 선택 타입이 현재 선택해야할 (currentType)과 다르면 return
        mapTile._germ.SelectGerm();

        _isFirstClick = false;
    }

    private void SecondClick()
    {

    }
}
