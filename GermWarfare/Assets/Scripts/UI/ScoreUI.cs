using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] GermType type;
    [SerializeField] TMP_Text _goldText;
    [SerializeField] TMP_Text _scoreText;


    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case GermType.Red:
                _scoreText.text = GameManager.Instance.ScoreRed.ToString();
                break;
            case GermType.Blue:
                _scoreText.text = GameManager.Instance.ScoreBlue.ToString();
                break;
            default:
                break;
        }
    }
}
