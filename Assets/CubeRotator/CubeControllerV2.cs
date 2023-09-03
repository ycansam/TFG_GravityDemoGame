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
        if (PlayerPhone.HasPhone())
            if (!cubeRotator.IsRotating)
                Controls();
    }

    private void Controls()
    {
        if (Input.GetKeyDown(keyRight))
        {
            if (!cubeRotator.IsRotating)
                HorizontalMove(1);
        }
        else
        if (Input.GetKeyDown(KeyLeft))
        {
            if (!cubeRotator.IsRotating)
                HorizontalMove(-1);
        }
        else
        if (Input.GetKeyDown(keyFront))
        {
            if (!cubeRotator.IsRotating)
                VerticalMove(1);
        }
        else
        if (Input.GetKeyDown(keyBack))
        {
            if (!cubeRotator.IsRotating)
                VerticalMove(-1);
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


    private void VerticalMove(int direction)
    {
        if (PlayerOnHelpWall.IsOnInferiorWall())
            PlayerOnInferiorWallConds(direction);
        else if (PlayerOnHelpWall.IsOnTopWall())
            PlayerOnTopWallConds(direction);
        else if (PlayerOnHelpWall.IsOnLeftWall())
            PlayerOnLeftWallConds(direction);
        else if (PlayerOnHelpWall.IsOnRightWall())
            PlayerOnRightWallConds(direction);
        else if (PlayerOnHelpWall.IsOnFrontWall())
            PlayerOnFrontWallConds(direction);
        else if (PlayerOnHelpWall.IsOnBackWall())
            PlayerOnBackWallConds(direction);
    }


    private void PlayerOnInferiorWallConds(int direction)
    {

        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.back * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.right * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.left * direction);
        }
    }

    private void PlayerOnTopWallConds(int direction)
    {

        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.back * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.left * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.right * direction);
        }
    }

    private void PlayerOnLeftWallConds(int direction)
    {

        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.back * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.down * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.up * direction);
        }
    }

    private void PlayerOnRightWallConds(int direction)
    {

        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.forward * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.back * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingFrontWall())
        {
            cubeRotator.RotateSmooth(Vector3.up * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingBackWall())
        {
            cubeRotator.RotateSmooth(Vector3.down * direction);
        }
    }

    private void PlayerOnFrontWallConds(int direction)
    {

        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.left * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.right * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.down * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.up * direction);
        }
    }

    private void PlayerOnBackWallConds(int direction)
    {


        if (PlayerLookingAtHelpWall.IsLookingInferiorWall())
        {
            cubeRotator.RotateSmooth(Vector3.right * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingTopWall())
        {
            cubeRotator.RotateSmooth(Vector3.left * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingRightWall())
        {
            cubeRotator.RotateSmooth(Vector3.up * direction);
        }
        if (PlayerLookingAtHelpWall.IsLookingLeftWall())
        {
            cubeRotator.RotateSmooth(Vector3.down * direction);
        }
    }

}
