using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager3 : LevelManager
{
    [SerializeField] FloorButtonTrigger floorBtn;
    private void Start()
    {
        PlayerSuit.SetPlayerSuitOn();
    }

    private void Update()
    {
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
