using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhone : MonoBehaviour
{
    [HideInInspector] private static bool hasPhone = false;
    private GameObject phone;
    private void Start()
    {
        phone = GameObject.FindGameObjectWithTag(Tags.PLAYER_PHONE);
    }

    private void Update()
    {
        if (hasPhone)
        {
            if (!phone.activeSelf)
            {
                phone.SetActive(true);
            }
        }
        else
        {
            if (phone.activeSelf)
            {
                phone.SetActive(false);
            }
        }
    }

    public static void SetPlayerPhoneOn()
    {
        hasPhone = true;
    }
    public static void SetPlayerPhoneOff()
    {
        hasPhone = false;
    }
    public static bool HasPhone()
    {
        return hasPhone;
    }
}
