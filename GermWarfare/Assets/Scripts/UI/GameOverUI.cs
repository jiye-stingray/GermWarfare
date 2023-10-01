﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : Singleton<GameOverUI>
{
    [SerializeField] GameObject _gameOverPanelObj;
    [SerializeField] TMP_Text _winText;
    

    // Start is called before the first frame update
    void Start()
    {
        _gameOverPanelObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(bool giveUp)
    {
        _gameOverPanelObj.SetActive(true);
        if (giveUp)
            _winText.text = InGameManager.Instance._currentType == GermType.Blue ? "Red" : "Blue";
        else
            _winText.text = GameManager.Instance.ScoreBlue > GameManager.Instance.ScoreRed ? "Blue" : "Red";
        _winText.text += " Win!";
    }

    public void ReStartBtnClickEvent()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void MenuBtnClickEvent()
    {
        SceneManager.LoadScene("StartScene");
    }
}
