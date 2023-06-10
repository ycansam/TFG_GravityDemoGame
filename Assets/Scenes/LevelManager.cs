using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool isLevelCompleted = false;
    [SerializeField] DoorAnimator doorAnimator;

    private void Update()
    {
        if (PlayerSuit.HasSuit() && !isLevelCompleted)
        {
            CompleteLevel1();
        }
    }

    public void CompleteLevel1()
    {
        Debug.Log("completed level 1");
        isLevelCompleted = true;
        doorAnimator.Activate();
    }
}
