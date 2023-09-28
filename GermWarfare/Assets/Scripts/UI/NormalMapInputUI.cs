using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalMapInputUI : MonoBehaviour
{
    [SerializeField] Slider _widthSlider;
    [SerializeField] Slider _heightSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtnClickEvent()
    {
        int[,] mapIndex = new int[(int)_widthSlider.value,(int)_heightSlider.value];
        // map Index Set
        for (int i = 0; i < mapIndex.GetLength(0); i++)
        {
            for (int j = 0; j < mapIndex.GetLength(1); j++)
            {
                mapIndex[i, j] = 1;          // 추후 조건으로 장애물 (0) 체크
            }
        }
        GameManager.Instance.InputMapIndex(mapIndex);
    }
}
