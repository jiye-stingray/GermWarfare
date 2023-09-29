using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    MapManager _mapManager => MapManager.Instance;

    public GermType _mapGermType;          // 현재 map에 type 상태
    private MapTile _mapTile;

    [SerializeField] private SpriteRenderer _germRender;
    [SerializeField] GameObject _selectImgObj;

    private void Awake()
    {
        _mapTile = GetComponentInParent<MapTile>();
    }

    public void SetGerm(GermType type)
    {
        _mapGermType = type;

        Color c = new Color();

        switch (type)
        {
            case GermType.None:
                c = new Color(1, 1, 1, 0);
                break;
            case GermType.Red:
                c = Color.red;
                break;
            case GermType.Blue:
                c = Color.blue;
                break;
            default:
                break;
        }

        _germRender.color = c;
        _selectImgObj.SetActive(false);
    }

    /// <summary>
    /// 세균이 선택되었을 때 
    /// 첫번째 클릭시
    /// </summary>
    public void SelectGerm()
    {
        if (InGameManager.Instance._currentType == GermType.None) return;
        _selectImgObj.SetActive(true);
    }

    public void Attack()
    {
        int[] dx = { -1, 0, 1 };
        int[] dy = { -1, 0, 1 };

        for (int i = 0; i < dx.Length; i++)
        {
            for (int j = 0; j < dx.Length; j++)
            {
                int newX = _mapTile.x + dx[i];
                int newY = _mapTile.y + dy[j];

                if (newX < 0 || newY < 0 || newX >= _mapManager._mapInt.GetLength(0) || newY >= _mapManager._mapInt.GetLength(1)) continue;

                if (_mapManager._mapTiles[newX, newY].TryGetComponent<NormalMapTile>(out NormalMapTile normalMapTile))
                {

                    normalMapTile = _mapManager._mapTiles[newX, newY].GetComponent<NormalMapTile>();

                    if (InGameManager.Instance._currentSelectTile.x == newX && InGameManager.Instance._currentSelectTile.y == newY)
                    {
                        normalMapTile._germ.SetGerm(InGameManager.Instance._currentType);
                        continue;
                    }


                    if (normalMapTile._germ._mapGermType == GermType.None) continue;

                    normalMapTile._germ.SetGerm(InGameManager.Instance._currentType);

                }

            }
        }


    }
}
