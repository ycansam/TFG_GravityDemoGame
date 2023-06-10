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
    }
    private void CatchAstraSuit(Transform item)
    {

        if (item.name.Contains("Suit"))
        {
            item.gameObject.SetActive(false);
            PlayerSuit.SetPlayerSuitOn();
        }
    }

}
