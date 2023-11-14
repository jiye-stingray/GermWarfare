using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : Singleton<GameOverUI>
{

    InGameManager _inGameManager => InGameManager.Instance;
    GameManager _gameManager => GameManager.Instance;

    [SerializeField] GameObject _gameOverPanelObj;
    [SerializeField] TMP_Text _winText;
    [SerializeField] Image _surrendBtnImg;

    [SerializeField] AddmobPanel _addmobPanel;
    void Start()
    {
        _gameOverPanelObj.SetActive(false);
    }

    private void Update()
    {
        _surrendBtnImg.color = (InGameManager.Instance._currentType == GermType.Red) ? Color.red : Color.blue; 
    }

    public void GameOver(bool giveUp)
    {
        _gameOverPanelObj.SetActive(true);

        _winText.text = "";

        if(GameManager.Instance._localIndex == 0)
        {

            if (giveUp)
            {
                _winText.text = _inGameManager._currentType == GermType.Blue ? "Red" : "Blue" ;
            }
            else
            {
                if (_gameManager.ScoreBlue == _gameManager.ScoreRed)
                {
                    _winText.text = "Draw!";
                    return;
                }
                else
                    _winText.text = _gameManager.ScoreBlue > _gameManager.ScoreRed ? "Blue" : "Red";

            }
            _winText.text += " Win!";

        }
        else
        {
            if (giveUp)
            {

                _winText.text = _inGameManager._currentType == GermType.Blue ? "빨강" : "파랑";
            }
            else
            {
                if (_gameManager.ScoreBlue == _gameManager.ScoreRed)
                {
                    _winText.text = "무승부!";
                    return;
                }
                else
                    _winText.text = _gameManager.ScoreBlue > _gameManager.ScoreRed ? "파랑" : "빨강";
            }
            _winText.text += " 승리!";
        }

    }

    public void ReStartBtnClickEvent()
    {
        _addmobPanel.SetDel(LoadInGameScene);
        _addmobPanel.ShowInterstitialAd(LoadInGameScene);

    }

    private void LoadInGameScene()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void MenuBtnClickEvent()
    {
        _addmobPanel.SetDel(LoadStartScene);
        _addmobPanel.ShowInterstitialAd(LoadStartScene);
    }

    private void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");

    }

    public void SurrenderBtnClickEvent()
    {
        GameManager.Instance.GameOver(true);
    }
}
