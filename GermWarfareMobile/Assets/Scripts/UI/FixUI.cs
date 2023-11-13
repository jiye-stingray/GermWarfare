using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixUI : MonoBehaviour
{
    CanvasScaler canvasScaler;

    private void Awake()
    {
        canvasScaler = GetComponent<CanvasScaler>();
    }
    private void Start()
    {

        SetResolution(); // �ʱ⿡ ���� �ػ� ����
    }

    /* �ػ� �����ϴ� �Լ� */
    public void SetResolution()
    {
         canvasScaler.referenceResolution *=  new Vector2((canvasScaler.referenceResolution.x / Screen.width), (Screen.height / canvasScaler.referenceResolution.y));
    }
}
