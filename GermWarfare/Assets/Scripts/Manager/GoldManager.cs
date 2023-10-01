using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GoldManager : Singleton<GoldManager>
{


    private int[,] _redMoneys = new int[26, 2];
    string _redGoldString = "";
    int _redIndexI = 0, _redIndexJ = 0;

    private int[,] _blueMoneys = new int[26, 2];
    string _blueGoldString = "";
    int _blueIndexI = 0, _blueIndexJ = 0;

    [Header("UI")]
    [SerializeField] TMP_Text _blueGoldText;
    [SerializeField] TMP_Text _redGoldText;



    void Start()
    {

    }

    void Update()
    {
        _blueGoldText.text = _blueGoldString;
        _redGoldText.text = _redGoldString;


    }

    public void AddGold(GermType germType)
    {
        switch (germType)
        {
            case GermType.Red:
                _redGoldString = CaculateGold(GermType.Red, _redMoneys,_redIndexI,_redIndexJ);
                break;
            case GermType.Blue:
                _blueGoldString = CaculateGold(GermType.Blue, _blueMoneys,_blueIndexI,_blueIndexJ);
                break;
            default:
                break;
        }
    }

    // 다음 숫자 시스템을 계산하는 함수
    string CaculateGold(GermType germType, int[,] moneys, int indexI, int indexJ)
    {
        int ran = Random.Range(1, 101);           
        moneys[0, 0] += ran;
        for (int i = 0; i < moneys.GetLength(0); i++)
        {
            for (int j = 0; j < moneys.GetLength(1); j++)
            {
                if (moneys[i, j] >= 1000)
                {
                    moneys[i, j] %= 1000;
                    if (j + 1 < moneys.GetLength(1))
                    {
                        moneys[i, j + 1] += 1;

                        if (i >= 1)
                            indexI++;
                        else
                            indexJ++;
                    }
                    else
                    {
                        if(i + 1 < moneys.GetLength(0))
                        {
                            moneys[i + 1, 0] += 1;
                            indexJ = 1;
                        }
                        else //MAX 상태 일때
                        {
                            moneys[i, j] = 999;
                        }
                    }
                }
            }

        }

        switch (germType)
        {
            case GermType.Red:
                _redMoneys = moneys;
                _redIndexI= indexI;
                _redIndexJ= indexJ;
                break;
            case GermType.Blue:
                _blueMoneys = moneys;
                _blueIndexI= indexI;
                _blueIndexJ= indexJ;
                break;
            default:
                break;
        }

        string alpha = " ABCDEFGHIJKLNMOPQRSTUVWXYZ";
        string s = moneys[indexI, indexJ].ToString();
        s += alpha[indexJ];
        s += alpha[indexI];

        return s.Replace(" ", string.Empty);


    }
}
