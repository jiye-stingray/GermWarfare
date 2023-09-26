using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    MapManager _mapManager => MapManager.Instance;

    public GermType _currentType = GermType.Blue;        // 파랑이 선공
    public bool isFirstClick = true;                    //  첫 클릭                       

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Click()
    {
        if(isFirstClick)
        {
            FirstClick();
        }
        else
        {
            SecondClick();
        }
    }
    
    private void FirstClick()
    {

    }

    private void SecondClick()
    {

    }
}
