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
    public Germ _germ;

    // 좌표
    public int x;
    public int y;

}
