using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] GameObject _normalMapInputPanle;
    [SerializeField] GameObject _customMapInputPanel;

    // Start is called before the first frame update
    void Start()
    {
        _normalMapInputPanle.SetActive(false);
        _customMapInputPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalMapBtnClickEvent()
    {
        _normalMapInputPanle.SetActive(true);
    }
    public void CustomMapBtnClickEvent()
    {
        _customMapInputPanel.SetActive(true);
    }

    // 돌아가기 버튼
    public void BackBtnClickEvent()
    {
        _normalMapInputPanle?.SetActive(false);
        _customMapInputPanel?.SetActive(false);
    }

}
