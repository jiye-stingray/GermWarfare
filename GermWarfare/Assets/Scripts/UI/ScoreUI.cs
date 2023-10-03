using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    GameManager gameManager => GameManager.Instance;

    [SerializeField] GermType type;
    [SerializeField] TMP_Text _scoreText;

    [Header("WinLose")]
    [SerializeField] Sprite[] _winLoseSprites;
    [SerializeField] Image _image;


    void Update()
    {
        switch (type)
        {
            case GermType.Red:
                _scoreText.text = gameManager.ScoreRed.ToString();

                if(gameManager.ScoreRed > gameManager.ScoreBlue)        // 이긴 상태
                {
                    _image.sprite = _winLoseSprites[0];
                }
                else
                    _image.sprite= _winLoseSprites[1];

                break;
            case GermType.Blue:
                _scoreText.text = gameManager.ScoreBlue.ToString();

                if (gameManager.ScoreBlue > gameManager.ScoreRed)        // 이긴 상태
                {
                    _image.sprite = _winLoseSprites[0];
                }
                else
                    _image.sprite = _winLoseSprites[1];
                break;
            default:
                break;
        }

    }
}
