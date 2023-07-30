using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObjects : MonoBehaviour
{
    private PlayerRays playerRays;
    private RaycastHit hit;
    [SerializeField] private Transform catchableObjectsPos;
    private Transform staticObjectCatched = null;

    [SerializeField] private CatchStaticObjetcs catchStaticObjetcs;

    private void Start()
    {
        playerRays = GetComponent<PlayerRays>();
    }
    void Update()
    {
        if (staticObjectCatched != null)
        {
            MoveCatchedObject();
            return;
        }
        FilterObjects();
    }

    private void MoveCatchedObject()
    {
        catchStaticObjetcs.UpdatePos(catchableObjectsPos, staticObjectCatched);
        if (Input.GetKeyDown(KeyCode.C))
        {
            catchStaticObjetcs.stopControlingObject(staticObjectCatched);
            staticObjectCatched = null;
        }
    }

    private void FilterObjects()
    {
        hit = playerRays.GetFirstForwardRayHit();
        Debug.Log(hit.transform.name);
        if (Input.GetKeyDown(KeyCode.C))
        {
            CatchAstraSuit(hit.transform);
            CatchAstraPhone(hit.transform);
            CatchStaticObject(hit.transform);
            PressStopButtonGravity(hit.transform);
        }
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
        if (item.name.Contains("Phone"))
        {
            item.gameObject.SetActive(false);
            PlayerPhone.SetPlayerPhoneOn();
        }
    }
    private void CatchStaticObject(Transform item)
    {
        if (item.tag == Tags.OBJECT_STATIC_CATCHABLE)
        {
            staticObjectCatched = item;
            catchStaticObjetcs.ControlObject(catchableObjectsPos, staticObjectCatched);
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
