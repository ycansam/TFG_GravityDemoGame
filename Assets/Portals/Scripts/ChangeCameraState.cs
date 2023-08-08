using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraState : MonoBehaviour
{
    [SerializeField] private int cubeNumber;
    [SerializeField] private PortalCamera camEnter3;
    [SerializeField] private PortalCamera camExit3;
    [SerializeField] private PortalCamera camEnter2;
    [SerializeField] private PlayerInCube playerInCube;


    private void ChangeNegState(bool state)
    {
        camEnter3.neg = state;
        camEnter2.neg = state;
    }

    private void CheckPlayerInCube3()
    {
        if (playerInCube.isPlayerOnCube() && cubeNumber == 3)
        {
            ChangeNegState(true);
        }
        else
        {
            ChangeNegState(false);
        }
    }

    private void CheckPlayerInCube2()
    {
        if (playerInCube.isPlayerOnCube() && cubeNumber == 2)
        {
            // camExit3.neg = false;
        }
        else
        {
            // camExit3.neg = true;
        }
    }


    private void Update()
    {
        CheckPlayerInCube3();
        CheckPlayerInCube2();
    }
}
