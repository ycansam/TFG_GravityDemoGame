using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObjects : MonoBehaviour
{
    private PlayerRays playerRays;
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
        RaycastHit[] raycastHits = playerRays.GetForwardRayHits();
        if (Input.GetKeyDown(KeyCode.C))
            for (int i = 0; i < raycastHits.Length; i++)
            {
                Transform item = raycastHits[i].transform;
                if (item.name.Contains("AstraSuit"))
                {
                    item.gameObject.SetActive(false);
                    PlayerSuit.SetPlayerSuitOn();
                }
            }


    }
    private void CatchItem()
    {

    }

}
