using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] GameObject _normalMapInputPanle;
    [SerializeField] GameObject _customMapInputPanel;

    void Start()
    {
        _normalMapInputPanle.SetActive(false);
        _customMapInputPanel.SetActive(false);
    }

    public void NormalMapBtnClickEvent()
    {
        _normalMapInputPanle.SetActive(true);
    }
    public void CustomMapBtnClickEvent()
    {
        _customMapInputPanel.SetActive(true);
    }

    // ���ư��� ��ư
    public void BackBtnClickEvent()
    {
        _normalMapInputPanle?.SetActive(false);
        _customMapInputPanel?.SetActive(false);
    }

    public void ExitBtnClickEvent()
    {
        Application.Quit();
    }
}
