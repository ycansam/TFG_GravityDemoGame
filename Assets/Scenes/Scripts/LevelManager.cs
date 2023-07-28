using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool isLevelCompleted = false;
    [SerializeField] protected DoorAnimator doorAnimator;

    private void Update()
    {
        if (PlayerSuit.HasSuit() && !isLevelCompleted)
        {
            CompleteLevel1();
        }
    }

    protected void UncompleteLevel()
    {
        if (isLevelCompleted)
        {
            isLevelCompleted = false;
            doorAnimator.Desactivate();
        }
    }
    
    protected void CompleteLevel()
    {
        if (!isLevelCompleted)
        {
            isLevelCompleted = true;
            doorAnimator.Activate();
        }
    }
    public void CompleteLevel1()
    {
        Debug.Log("completed level 1");
        if (!isLevelCompleted)
        {
            isLevelCompleted = true;
            doorAnimator.Activate();
        }
    }

}
