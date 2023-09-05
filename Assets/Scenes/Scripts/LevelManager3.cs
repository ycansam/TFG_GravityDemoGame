using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager3 : LevelManager
{
    [SerializeField] FloorButtonTrigger floorBtn;
    private void Start()
    {
        PlayerPhone.SetPlayerPhoneOff();
        PlayerSuit.SetPlayerSuitOn();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CompleteLevelAdmin();
        if (floorBtn.IsActivated)
        {
            CompleteLevel();
        }
        else
        {
            UncompleteLevel();
        }
    }

}
