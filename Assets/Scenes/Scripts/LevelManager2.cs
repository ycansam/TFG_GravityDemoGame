using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager2 : LevelManager
{
    [SerializeField] FloorButtonTrigger floorBtn;

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
