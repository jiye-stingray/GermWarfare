using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : Singleton<GameOverUI>
{
    [SerializeField] GameObject _gameOverPanelObj;
    [SerializeField] TMP_Text _winText;

    void Start()
    {
        _gameOverPanelObj.SetActive(false);
    }


    public void GameOver(bool giveUp)
    {
        _gameOverPanelObj.SetActive(true);

        _winText.text = "";

        if(LangaugeManager.Instance._localIndex == 0)
        {
            if (giveUp)
            {
                _winText.text = InGameManager.Instance._currentType == GermType.Blue ? "Red" : "Blue" ;
            }
            else
            {
                _winText.text = GameManager.Instance.ScoreBlue > GameManager.Instance.ScoreRed ? "Blue" : "Red";

            }
            _winText.text += " Win!";

        }
        else
        {
            if (giveUp)
            {

                _winText.text = InGameManager.Instance._currentType == GermType.Blue ? "빨강" : "파랑";
            }
            else
            {
                _winText.text = GameManager.Instance.ScoreBlue > GameManager.Instance.ScoreRed ? "파랑" : "빨강";
            }
            _winText.text += " 승리!";
        }

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
