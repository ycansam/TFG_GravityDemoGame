using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    [HideInInspector]
    public bool isTeleporting = false;

    [HideInInspector]
    public bool hasEnteredFromBack = false;

    public Material objectMat;
}
