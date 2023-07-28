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
        if (Input.GetKeyDown(KeyCode.C))
            CatchAstraSuit(hit.transform);
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
    private void PressStopButtonGravity(Transform item)
    {
        Debug.Log(item.tag);
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
