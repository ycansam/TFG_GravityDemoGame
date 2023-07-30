using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhone : MonoBehaviour
{
    [HideInInspector] private static bool hasPhone = false;

    public static void SetPlayerPhoneOn()
    {
        hasPhone = true;
    }

    public static bool HasPhone()
    {
        return hasPhone;
    }
}
