using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GermType
{
    None,
    Red,
    Blue
}

public class MapTile : MonoBehaviour
{
    public GermType _mapGermType;          // ���� map�� type ����

    // ��ǥ
    public int x;
    public int y;

}
