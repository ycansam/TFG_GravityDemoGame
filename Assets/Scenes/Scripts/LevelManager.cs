using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool isLevelCompleted = false;
    public static bool isLevelCompletedAdmin = false;
    [SerializeField] protected DoorAnimator doorAnimator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (PlayerSuit.HasSuit() && !isLevelCompleted)
        {
            CompleteLevel1();
        }
        CompleteLevelAdmin();
    }

    protected void CompleteLevelAdmin()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isLevelCompletedAdmin = true;
        }
        if (isLevelCompletedAdmin)
        {
            CompleteLevel();
        }
    }

    protected void UncompleteLevel()
    {
        if (!isLevelCompletedAdmin)
        {
            if (isLevelCompleted)
            {
                isLevelCompleted = false;
                doorAnimator.Desactivate();
            }
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
