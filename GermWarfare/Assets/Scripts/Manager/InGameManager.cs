using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    MapManager _mapManager => MapManager.Instance;

    public GermType _currentType = GermType.Blue;        // �Ķ��� ����
    public bool isFirstClick = true;                    //  ù Ŭ��                       

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
