using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : Singleton<GoldManager> 
{
    InGameManager _inGameManager => InGameManager.Instance;

    [Header("Gold")]
    private string _goldBlue;
    public string GoldBlue { get { return _goldBlue; } set { _goldBlue = value; } }

    private string _goldRed;
    public string GoldRed { get { return _goldRed; } set { _goldRed = value; } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
