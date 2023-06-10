using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuit : MonoBehaviour
{
    [HideInInspector] private static bool hasSuit = false;

    public static void SetPlayerSuitOn()
    {
        hasSuit = true;
    }

    public static bool HasSuit()
    {
        return hasSuit;
    }
}
