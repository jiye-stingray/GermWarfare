using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    int _scoreBlue = 0;
    int _scoreRed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetScore()
    {

    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}
