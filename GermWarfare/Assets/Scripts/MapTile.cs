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
    public GermType _mapGermType;          // 현재 map에 type 상태

    // 좌표
    public int x;
    public int y;

}
