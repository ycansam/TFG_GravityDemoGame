using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectColor : MonoBehaviour
{
    [SerializeField]
    private int color = 0;

    public int Color
    {
        get { return color; }
    }
}
