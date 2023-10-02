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



    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case GermType.Red:
                _scoreText.text = gameManager.ScoreRed.ToString();

                if(gameManager.ScoreRed > gameManager.ScoreBlue)        // �̱� ����
                {
                    _image.sprite = _winLoseSprites[0];
                }
                else
                    _image.sprite= _winLoseSprites[1];

                break;
            case GermType.Blue:
                _scoreText.text = gameManager.ScoreBlue.ToString();

                if (gameManager.ScoreBlue > gameManager.ScoreRed)        // �̱� ����
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
