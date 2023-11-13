using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NormalMapInputUI : MonoBehaviour
{
    [SerializeField] Slider _widthSlider;
    [SerializeField] Slider _heightSlider;

    [SerializeField] TMP_Text _widthText;
    [SerializeField] TMP_Text _heightText;

    int[,] mapIndex;


    void Update()
    {
        _widthText.text = ((int)_widthSlider.value).ToString();
        _heightText.text = ((int)_heightSlider.value).ToString();
    }

    public void StartBtnClickEvent()
    {
        mapIndex = new int[(int)_widthSlider.value,(int)_heightSlider.value];
        // map Index Set
        for (int i = 0; i < mapIndex.GetLength(0); i++)
        {
            for (int j = 0; j < mapIndex.GetLength(1); j++)
            {
                mapIndex[i, j] = 1;          
            }
        }

        GameManager.Instance.InputMapIndex(mapIndex);
        SceneManager.LoadScene("InGameScene");
    }
}
