using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallController : MonoBehaviour
{
    [SerializeField] PlayerWallMarker playerWallMarker;

    void Update()
    {
        Controls();
    }

    private void Controls()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerWallMarker.IsMarkerActivated())
        {
            RotatePlayer();
        }
    }

    private void RotatePlayer()
    {
        IsPlayerOnInferiorWall();
        IsPlayerOnRightWall();
        IsPlayerOnFrontWall();
        IsPlayerOnLeftWall();
        IsPlayerOnBackWall();
        IsPlayerOnTopWall();

    }

    private void IsPlayerOnInferiorWall()
    {
        if (PlayerOnHelpWall.IsOnInferiorWall())
        {
            if (PlayerLookingAtHelpWall.IsLookingRightWall())
            {
                RotatePlayer(0f, 0f, 90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingFrontWall())
            {
                RotatePlayer(-90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingLeftWall())
            {
                RotatePlayer(0f, 0f, -90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingBackWall())
            {
                RotatePlayer(90f);
            }
        }
    }

    private void IsPlayerOnRightWall()
    {
        if (PlayerOnHelpWall.IsOnRightWall())
        {
            if (PlayerLookingAtHelpWall.IsLookingFrontWall())
            {
                RotatePlayer(0f, -90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
            {
                RotatePlayer(0f, 0f, -90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingBackWall())
            {
                RotatePlayer(0f, 90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingTopWall())
            {
                RotatePlayer(0f, 0f, 90f);
            }
        }
    }

    private void IsPlayerOnFrontWall()
    {
        if (PlayerOnHelpWall.IsOnFrontWall())
        {
            if (PlayerLookingAtHelpWall.IsLookingLeftWall())
            {
                RotatePlayer(0f, -90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
            {
                RotatePlayer(90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingRightWall())
            {
                RotatePlayer(0f, 90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingTopWall())
            {
                RotatePlayer(-90f);
            }
        }
    }
    private void IsPlayerOnLeftWall()
    {
        if (PlayerOnHelpWall.IsOnLeftWall())
        {
            if (PlayerLookingAtHelpWall.IsLookingBackWall())
            {
                RotatePlayer(0f, -90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
            {
                RotatePlayer(0f, 0f, 90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingFrontWall())
            {
                RotatePlayer(0f, 90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingTopWall())
            {
                RotatePlayer(0f, 0f, -90f);
            }
        }
    }
    private void IsPlayerOnBackWall()
    {
        if (PlayerOnHelpWall.IsOnBackWall())
        {
            if (PlayerLookingAtHelpWall.IsLookingLeftWall())
            {
                RotatePlayer(0f, 90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
            {
                RotatePlayer(-90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingRightWall())
            {
                RotatePlayer(0f, -90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingTopWall())
            {
                RotatePlayer(90f);
            }
        }
    }

    private void IsPlayerOnTopWall()
    {
        if (PlayerOnHelpWall.IsOnTopWall())
        {
            if (PlayerLookingAtHelpWall.IsLookingRightWall())
            {
                RotatePlayer(0f, 0f, -90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingFrontWall())
            {
                RotatePlayer(90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingLeftWall())
            {
                RotatePlayer(0f, 0f, 90f);
            }
            if (PlayerLookingAtHelpWall.IsLookingBackWall())
            {
                RotatePlayer(-90f);
            }
        }
    }

    private void RotatePlayer(float x = 0f, float y = 0f, float z = 0f)
    {
        transform.Rotate(new Vector3(x, y, z), Space.World);
    }


}
