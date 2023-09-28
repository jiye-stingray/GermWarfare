using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] GameObject _normalMapInputPanle;

    // Start is called before the first frame update
    void Start()
    {
        _normalMapInputPanle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalMapBtnClickEvent()
    {
        _normalMapInputPanle.SetActive(true);
    }

}
