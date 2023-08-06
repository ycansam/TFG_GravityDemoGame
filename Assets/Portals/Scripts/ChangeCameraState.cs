using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraState : MonoBehaviour
{
    [SerializeField] private PortalCamera camEnter3;
    [SerializeField] private PortalCamera camExit3;
    [SerializeField] private PortalCamera camEnter2;
    [SerializeField] private PlayerInCube playerInCube;
    public void ChangeNegState(bool state)
    {
        camEnter3.neg = state;
        camExit3.neg = state;
        camEnter2.neg = state;
    }

    private void Update()
    {
        if (playerInCube.isPlayerOnCube())
        {
            ChangeNegState(true);
        }else{
            ChangeNegState(false);
        }
    }
}
