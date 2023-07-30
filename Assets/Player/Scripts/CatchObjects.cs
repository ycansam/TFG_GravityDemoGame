using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObjects : MonoBehaviour
{
    private PlayerRays playerRays;
    RaycastHit hit;
    RaycastHit[] raycastHits;
    private void Start()
    {
        playerRays = GetComponent<PlayerRays>();
    }
    void Update()
    {
        FilterObjects();
    }

    private void FilterObjects()
    {
        hit = playerRays.GetFirstForwardRayHit();
        Debug.Log(hit.transform.name);
        if (Input.GetKeyDown(KeyCode.C))
            CatchAstraSuit(hit.transform);
        if (Input.GetKeyDown(KeyCode.C))
            CatchAstraPhone(hit.transform);
        if (Input.GetKeyDown(KeyCode.C))
            PressStopButtonGravity(hit.transform);

    }
    private void CatchAstraSuit(Transform item)
    {
        if (item.name.Contains("Suit"))
        {
            item.gameObject.SetActive(false);
            PlayerSuit.SetPlayerSuitOn();
        }
    }

    private void CatchAstraPhone(Transform item)
    {
        Debug.Log(item.name);
        if (item.name.Contains("Phone"))
        {
            item.gameObject.SetActive(false);
            PlayerPhone.SetPlayerPhoneOn();
        }
    }

    private void PressStopButtonGravity(Transform item)
    {
        if (item.tag == Tags.BUTTON_GRAVITY)
        {
            Debug.Log("buttonpressed");
            ButtonGravity btn = item.GetComponent<ButtonGravity>();
            if (btn.useGravity)
            {
                Debug.Log("buttonpressed1");
                btn.DisableCubesGravity();
            }
            else
            {
                Debug.Log("buttonpressed2");
                btn.EnableCubesGravity();
            }
        }
    }
}
