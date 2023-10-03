using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int _scoreBlue = 0;
    public int ScoreBlue { get { return _scoreBlue; } set { _scoreBlue = value; } }

    [SerializeField] private int _scoreRed = 0;
    public int ScoreRed { get { return _scoreRed;} set { _scoreRed = value; } }

    public int[,] _mapIndex;


    /// <summary>
    /// ∏  ¿Œµ¶Ω∫ ¿˙¿Â
    /// </summary>
    public void InputMapIndex(int[,] mapIndex)
    {
        _mapIndex = mapIndex;
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
                if(mapTiles[i, j].TryGetComponent<NormalMapTile>(out NormalMapTile normalMapTile))
                {
                    switch (normalMapTile._germ._mapGermType)
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
        }

        if (_scoreBlue == 0 || _scoreRed == 0) GameOver(false);      
    }

    public void GameOver(bool giveUp)
    {
        GameOverUI.Instance.GameOver(giveUp);
    }

}
