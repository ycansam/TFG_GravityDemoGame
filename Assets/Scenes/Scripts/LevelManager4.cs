using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager4 : LevelManager
{
    void Start()
    {
        PlayerPhone.SetPlayerPhoneOn();
        PlayerSuit.SetPlayerSuitOn();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        CompleteLevelAdmin();
    }

}
