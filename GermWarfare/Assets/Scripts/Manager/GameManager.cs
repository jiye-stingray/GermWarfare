using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int _scoreBlue = 0;
    [SerializeField] private int _scoreRed = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetScore()
    {
        _scoreRed = 0;
        _scoreBlue = 0;

        MapTile[,] mapTiles = MapManager.Instance._mapTiles;

        for (int i = 0; i < mapTiles.GetLength(0); i++)
        {
            for (int j = 0; j < mapTiles.GetLength(1); j++)
            {
                switch (mapTiles[i,j]._germ._mapGermType)
                {
                    case GermType.Red:
                        _scoreRed++;
                        break;
                    case GermType.Blue:
                        _scoreBlue++;
                        break;
                    default:
                        break;
                }
            }
        }

        if (_scoreBlue == 0 || _scoreRed == 0) GameOver();      
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }


}
