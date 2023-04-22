using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(CubeRotator))]
public class CubeControllerV2 : MonoBehaviour
{

    [SerializeField]
    KeyCode keyRight = KeyCode.E;
    [SerializeField]
    KeyCode KeyLeft = KeyCode.Q;
    [SerializeField]
    KeyCode keyFront = KeyCode.R;
    [SerializeField]
    KeyCode keyBack = KeyCode.F;
    CubeRotator cubeRotator;

    private void Start()
    {
        cubeRotator = GetComponent<CubeRotator>();
    }

    void Update()
    {
        if (!cubeRotator.IsRotating)
            Controls();
    }

    private void Controls()
    {
        if (Input.GetKeyDown(keyRight))
        {
            HorizontalMove(1);
        }
        if (Input.GetKeyDown(KeyLeft))
        {
            HorizontalMove(-1);
        }
        if (Input.GetKeyDown(keyFront) || Input.GetKeyDown(keyBack))
        {
            VerticalMove();
        }
    }

    private void HorizontalMove(int direction)
    {
        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.right * direction);
        }
        else
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward * direction);
        }
        else
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.left * direction);
        }
        else
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.back * direction);
        }
        else
        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.down * direction);
        }
        else
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.up * direction);
        }
    }


    private void VerticalMove()
    {
        if (PlayerOnHelpWall.IsOnInferiorWall())
            PlayerOnInferiorWallConds();
        else if (PlayerOnHelpWall.IsOnTopWall())
            PlayerOnTopWallConds();
        else if (PlayerOnHelpWall.IsOnLeftWall())
            PlayerOnLeftWallConds();
        else if (PlayerOnHelpWall.IsOnRightWall())
            PlayerOnRightWallConds();
        else if (PlayerOnHelpWall.IsOnFrontWall())
            PlayerOnFrontWallConds();
        else if (PlayerOnHelpWall.IsOnBackWall())
            PlayerOnBackWallConds();
    }


    private void PlayerOnInferiorWallConds()
    {

        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.back);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.right);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.left);
        }
    }

    private void PlayerOnTopWallConds()
    {

        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.back);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.left);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.right);
        }
    }

    private void PlayerOnLeftWallConds()
    {

        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.back);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.down);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.up);
        }
    }

    private void PlayerOnRightWallConds()
    {

        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.back);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.up);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.down);
        }
    }

    private void PlayerOnFrontWallConds()
    {

        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.left);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.right);
        }
        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.down);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.up);
        }
    }

    private void PlayerOnBackWallConds()
    {


        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.right);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.left);
        }
        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.up);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.down);
        }
    }

}
