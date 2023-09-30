using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GoldManager : Singleton<GoldManager>
{


    private int[,] _moneys = new int[26, 2]; 

    [Header("UI")]
    [SerializeField] TMP_Text _blueGoldText;
    [SerializeField] TMP_Text _redGoldText;



    void Start()
    {

    }

    [ContextMenu("Add")]
    public void Add()
    {
        //int ran = Random.Range(1, 101);
        int ran = Random.Range(100, 101);           // 추후 입력 위처럼 수정~ 테스트 용
        _moneys[0, 0] += ran;
        int indexI = 0, indexJ = 0;
        for (int i = 0; i < _moneys.GetLength(0); i++)
        {
            for (int j = 0; j < _moneys.GetLength(1); j++)
            {
                if (_moneys[i,j] >= 1000)
                {
                    if(j + 1 < _moneys.GetLength(1))
                    {
                        _moneys[i, j] %= 1000;
                        _moneys[i, j + 1] += 1;
                    }
                    else
                    {
                        _moneys[i, j] %= 1000;
                        _moneys[i + 1, 0] += 1;
                    }
                }

                if (_moneys[i, j] != 0 && indexI == 0 && indexJ == 0)
                {
                    indexI= i;
                    indexJ= j;
                }
            }
        }

        string alpha = " ABCDEFGHIJKLNMOPQRSTUVWXYZ";
        string s = _moneys[indexI,indexJ].ToString();
        Debug.Log(indexI + " " + indexJ);
        s += alpha[indexJ];
        // I랑 J 더해놓고 공백 제거 하는거 내일 해보고 테스트~
        
/*        if (indexI != 0)
        {
            Debug.Log("Df" + (char)((indexI - 1) / 26));
            s += ((char)((indexI - 1) / 26)).ToString();
        }
        else if (indexJ != 0)
            s += ((char)((indexJ - 1) / 26)).ToString();*/

        Debug.Log(s);
    }

    void Update()
    {


    }

    public void AddGold(GermType germType)
    {

    }

    // 다음 숫자 시스템을 계산하는 함수
    void CaculateGold(string currentSystem, int totalGold)
    {

    }

}
