using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuit : MonoBehaviour
{
    [HideInInspector] private static bool hasSuit = false;
    [SerializeField] private GameObject suit;
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject AstraWihoutPhone;

    private void Update()
    {
        if (hasSuit && PlayerPhone.HasPhone())
        {
            if (!suit.activeSelf)
            {
                suit.SetActive(true);
                head.SetActive(true);
            }
            if (AstraWihoutPhone.activeSelf)
                AstraWihoutPhone.SetActive(false);
        }
        else if (hasSuit && !PlayerPhone.HasPhone())
        {
            if (!suit.activeSelf)
            {
                suit.SetActive(false);
                head.SetActive(false);
            }
            if (!AstraWihoutPhone.activeSelf)
                AstraWihoutPhone.SetActive(true);

        }
        else if (!hasSuit)
        {
            if (suit.activeSelf)
            {
                suit.SetActive(false);
                head.SetActive(false);
                AstraWihoutPhone.SetActive(false);
            }
        }
    }

    public static void SetPlayerSuitOn()
    {
        hasSuit = true;
    }
    public static void SetPlayerSuitOff()
    {
        hasSuit = false;
    }

    public static bool HasSuit()
    {
        return hasSuit;
    }
}
