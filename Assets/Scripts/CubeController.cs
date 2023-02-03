using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CubeController : MonoBehaviour
{
    [SerializeField]
    private Transform playerHead;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private bool isRotating = false;
    public bool IsRotating
    {
        get { return this.isRotating; }
        private set { this.isRotating = value; }
    }

    [SerializeField]
    private float rotationSpeed = 5f;
    bool rotating = false;
    [SerializeField]
    KeyCode keyRight = KeyCode.E;
    [SerializeField]
    KeyCode keyFront = KeyCode.R;

    private String playerLookingAtInteriorWall = "";
    private String playerOnWall = "";

    void Update()
    {
        Controls();
        CheckPlayerLookingAt();
        
    }


    private void CheckPlayerLookingAt()
    {
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 50;
        Vector3 down = playerHead.TransformDirection(Vector3.up) * 50;

        Debug.DrawRay(playerHead.position, forward, Color.green);
        Debug.DrawRay(playerHead.position, down, Color.red);

        RaycastHit[] hits;
        RaycastHit[] hitsDown;
        hits = Physics.RaycastAll(playerHead.position, forward, 100.0F);
        hitsDown = Physics.RaycastAll(playerHead.position, down, 50.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (!hit.transform.gameObject.name.Contains("Help") && hit.transform.gameObject.name.Contains("Wall"))
            {
                playerLookingAtInteriorWall = hit.transform.gameObject.name;
                hitsDown = Physics.RaycastAll(playerHead.position, down, 50.0F);
            }
        }

        for (int i = 0; i < hitsDown.Length; i++)
        {
            RaycastHit hit = hitsDown[i];
            if (!hit.transform.gameObject.name.Contains("Help") && hit.transform.gameObject.name.Contains("Wall"))
            {
                playerOnWall = hit.transform.gameObject.name;
            }
        }

    }

    private void Controls()
    {
        bool playerOnLeftWall =
       playerOnWall.Contains("Left") || playerOnWall.Contains("Right");

        if (playerLookingAtInteriorWall.Contains("Front"))
            RotateCubeByLookingAtAnyWall(transform.forward, transform.up, transform.right);
        else if (playerLookingAtInteriorWall.Contains("Backward"))
            RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up * -1, transform.right * -1);
        else if (playerLookingAtInteriorWall.Contains("Right"))
            if (playerOnWall.Contains("Top"))
                RotateCubeByLookingAtAnyWall(transform.forward, transform.up * -1, transform.right * -1, keyFront, keyRight);
            else
                RotateCubeByLookingAtAnyWall(transform.forward, transform.up, transform.right, keyFront, keyRight);
        else if (playerLookingAtInteriorWall.Contains("Left"))
            if (playerOnWall.Contains("Top"))
                RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up, transform.right, keyFront, keyRight);
            else
                RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up * -1, transform.right * -1, keyFront, keyRight);
        else if (playerLookingAtInteriorWall.Contains("Inferior"))
            if (playerOnLeftWall)
                RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up * -1, transform.right * -1, keyFront, keyRight);
            else
                RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up * -1, transform.right * -1);
        else if (playerLookingAtInteriorWall.Contains("Top"))
            if (playerOnLeftWall)
                RotateCubeByLookingAtAnyWall(transform.forward, transform.up, transform.right, keyFront, keyRight);
            else
                RotateCubeByLookingAtAnyWall(transform.forward, transform.up, transform.right);
    }


    // direction 1 forward, direction 2 up, direction 3 right
    private void RotateCubeByLookingAtAnyWall(Vector3 direction1, Vector3 direction2, Vector3 direction3,
     KeyCode rightKey = KeyCode.E, KeyCode frontKey = KeyCode.R
     )
    {

        bool playerOnRightWallCond =
            playerOnWall.Contains("Right");

        bool playerOnLeftWallCond =
            playerOnWall.Contains("Left");
        bool playerOnFrontWall =
            playerOnWall.Contains("Front");
        bool playerOnTopWall =
            playerOnWall.Contains("Top");
        bool playerOnInferiorWall =
            playerOnWall.Contains("Inferior");
        bool playerOnBackWall =
            playerOnWall.Contains("Back");

        bool playerOnInferiorWallAndLookingLeftRight =
        playerOnWall.Contains("Inferior") && playerLookingAtInteriorWall.Contains("Left") || playerOnWall.Contains("Inferior") && playerLookingAtInteriorWall.Contains("Right");

        bool playerOnRightWallAndLookingTopInferior =
                playerOnWall.Contains("Right") && playerLookingAtInteriorWall.Contains("Top") && player.parent != null || playerOnWall.Contains("Right") && playerLookingAtInteriorWall.Contains("Inferior") && player.parent != null;

        Int16 playerOnRightWallAndLookingFrontBack =
       playerOnWall.Contains("Right") && playerLookingAtInteriorWall.Contains("Front") && player.parent != null || playerLookingAtInteriorWall.Contains("Back") ? (short)-1 : (short)1;

        Int16 inverted = playerOnLeftWallCond && player.parent != null ? (short)-1 : (short)1;
        Int16 invertedOnTopWall = playerOnTopWall && player.parent != null ? (short)-1 : (short)1;
        Int16 invertedOnBackWall = playerOnBackWall && player.parent != null ? (short)-1 : (short)1;

        bool playerOnTopWallLookingBackFront =
            playerOnWall.Contains("Top") && playerLookingAtInteriorWall.Contains("Back") && player.parent != null || playerOnWall.Contains("Top") && playerLookingAtInteriorWall.Contains("Front") && player.parent != null;

        bool playerOnTopWallLookingRightLeft =
            playerOnWall.Contains("Top") && playerLookingAtInteriorWall.Contains("Right") && player.parent != null || playerOnWall.Contains("Top") && playerLookingAtInteriorWall.Contains("Left") && player.parent != null;

        bool playerOnLeftWallAndLookingBackFront =
            playerOnWall.Contains("Left") && playerLookingAtInteriorWall.Contains("Back") && player.parent != null || playerOnWall.Contains("Left") && playerLookingAtInteriorWall.Contains("Front") && player.parent != null;

        bool playerOnLeftWallAndLookingTopInferior =
                   playerOnWall.Contains("Left") && playerLookingAtInteriorWall.Contains("Top") && player.parent != null || playerOnWall.Contains("Left") && playerLookingAtInteriorWall.Contains("Inferior") && player.parent != null;

        bool playerOnFrontWallAndLookingLeftRight =
                          playerOnWall.Contains("Front") && playerLookingAtInteriorWall.Contains("Left") && player.parent != null || playerOnWall.Contains("Front") && playerLookingAtInteriorWall.Contains("Right") && player.parent != null;

        bool playerOnFrontWallAndLookingTopInferior =
                         playerOnWall.Contains("Front") && playerLookingAtInteriorWall.Contains("Top") && player.parent != null || playerOnWall.Contains("Front") && playerLookingAtInteriorWall.Contains("Inferior") && player.parent != null;

        if (Input.GetKeyDown(rightKey) && !rotating)
        {
            if (CheckCubeEuler(0f, 0f, 0f))
            {
                Debug.Log("a");
                if (playerOnFrontWall || playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f * invertedOnTopWall * playerOnRightWallAndLookingFrontBack));
            }
            else if (CheckCubeEuler(0f, 0f, 90f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else if (playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f * invertedOnTopWall * playerOnRightWallAndLookingFrontBack));
            }
            else if (CheckCubeEuler(0f, 0f, 180f))
            {
                Debug.Log("a");
                if (playerOnFrontWall || playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnBackWall));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f * invertedOnTopWall * playerOnRightWallAndLookingFrontBack));

            }
            else

            if (CheckCubeEuler(0f, 0f, 270f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f * invertedOnTopWall * playerOnRightWallAndLookingFrontBack));
            }
            else if (CheckCubeEuler(90f, 0f, 0f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f * playerOnRightWallAndLookingFrontBack));

            }
            else if (CheckCubeEuler(90f, 90f, 0f))
            {

                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else
                    StartCoroutine(RotateEase(direction3 * 90f * playerOnRightWallAndLookingFrontBack));
            }
            else if (CheckCubeEuler(90f, 180f, 0f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else
                    StartCoroutine(RotateEase(direction2 * 90f * playerOnRightWallAndLookingFrontBack));
            }
            else if (CheckCubeEuler(90f, 270f, 0f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else if (playerOnLeftWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else
                    StartCoroutine(RotateEase(direction3 * -90f * playerOnRightWallAndLookingFrontBack));
            }
            else

            if (CheckCubeEuler(0f, 180f, 180f))
            {
                Debug.Log("a");

                if (playerOnFrontWall || playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnBackWall));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f));

            }
            else if (CheckCubeEuler(0f, 180f, 270f))
            {
                Debug.Log("a");

                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnFrontWall)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f));

            }
            else if (CheckCubeEuler(0f, 180f, 0f))
            {
                Debug.Log("a");

                if (playerOnFrontWall || playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f));

            }
            else if (CheckCubeEuler(0f, 180f, 90f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f));
            }

            if (CheckCubeEuler(270f, 0f, 0f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f));
            }
            else if (CheckCubeEuler(270f, 90f, 0f))
            {

                if (playerOnFrontWall)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else
                    StartCoroutine(RotateEase(direction3 * -90f));
                Debug.Log("a");
            }
            else if (CheckCubeEuler(270f, 180f, 0f))
            {
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else
                    StartCoroutine(RotateEase(direction2 * 90f));
                Debug.Log("a");
            }
            else if (CheckCubeEuler(270f, 270f, 0f))
            {
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else if (playerOnInferiorWallAndLookingLeftRight || playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else
                    StartCoroutine(RotateEase(direction3 * 90f));
                Debug.Log("a");
            }
            else


            if (CheckCubeEuler(0f, 90f, 90f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else if (playerOnRightWallCond)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnTopWall));
            }
            else if (CheckCubeEuler(0f, 90f, 180f))
            {
                if (playerOnFrontWall || playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnBackWall));
                else if (playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else
                    StartCoroutine(RotateEase(direction3 * 90f * invertedOnTopWall));
                Debug.Log("a");

            }
            else if (CheckCubeEuler(0f, 90f, 270f))
            {
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else if (playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnTopWall));
                Debug.Log("a");


            }
            else if (CheckCubeEuler(0f, 90f, 0f))
            {
                if (playerOnFrontWall || playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));
                else if (playerOnRightWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else
                    StartCoroutine(RotateEase(direction3 * -90f * invertedOnTopWall));
                Debug.Log("a");
            }
            else
            if (CheckCubeEuler(0f, 270f, 270f))
            {

                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnFrontWallAndLookingLeftRight)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else if (playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else
                    StartCoroutine(RotateEase(direction2 * 90f));
                Debug.Log("a");
            }
            else if (CheckCubeEuler(0f, 270f, 0f))
            {
                if (playerOnFrontWall || playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));
                else if (playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else
                    StartCoroutine(RotateEase(direction3 * 90f));
                Debug.Log("a");

            }
            else if (CheckCubeEuler(0f, 270f, 90f))
            {
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else if (playerOnFrontWallAndLookingLeftRight || playerOnFrontWallAndLookingTopInferior)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f));

                Debug.Log("a");
            }
            else if (CheckCubeEuler(0f, 270f, 180f))
            {
                Debug.Log("a");
                if (playerOnBackWall)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else if (playerOnFrontWallAndLookingTopInferior || playerOnFrontWallAndLookingLeftRight)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else if (playerOnRightWallAndLookingTopInferior || playerOnTopWallLookingRightLeft)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else
                    StartCoroutine(RotateEase(direction3 * -90f));


            }

        }

        if (Input.GetKeyDown(frontKey) && !rotating)
        {
            if (CheckCubeEuler(0f, 0f, 0f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * 90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * 90f * invertedOnTopWall * invertedOnBackWall));

                Debug.Log("a");
            }
            else if (CheckCubeEuler(90f, 0f, 0f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * -90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * 90f * invertedOnTopWall * invertedOnBackWall));
                Debug.Log("a");
            }
            else if (CheckCubeEuler(270f, 0f, 0f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * 90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * 90f * invertedOnTopWall * invertedOnBackWall));
                Debug.Log("a");
            }
            else if (CheckCubeEuler(0f, 180f, 180f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * -90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * 90f * invertedOnTopWall * invertedOnBackWall));
                Debug.Log("a");
            }
            else
            // Cuando ha rotado z en 270º
            if (CheckCubeEuler(0f, 0f, 270f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * -90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(0f, 270f, 270f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond)
                    StartCoroutine(RotateEase(direction3 * -90f));
                else if (playerOnTopWallLookingRightLeft || playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else if (playerOnLeftWallAndLookingBackFront)
                    StartCoroutine(RotateEase(direction3 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f * inverted * invertedOnBackWall));

            }
            else
            if (CheckCubeEuler(0f, 180f, 270f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * -90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));
                Debug.Log("a");
            }
            else
            if (CheckCubeEuler(0f, 90f, 270f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * -90f * inverted));
                else if (playerOnTopWallLookingRightLeft || playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else
                    StartCoroutine(RotateEase(direction1 * 90f * invertedOnBackWall));
                Debug.Log("a");
            }
            // Cuando ha rotado z en 180º
            else if (CheckCubeEuler(0f, 0f, 180f))
            {
                Debug.Log("a");

                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * -90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * -90f * invertedOnTopWall * invertedOnBackWall));
            }
            else
             if (CheckCubeEuler(90f, 180f, 0f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * -90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * -90f * invertedOnTopWall * invertedOnBackWall));
                Debug.Log("a");
            }
            else
             if (CheckCubeEuler(0f, 180f, 0f))
            {

                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * 90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * -90f * invertedOnTopWall * invertedOnBackWall));
                Debug.Log("a");
            }
            else
             if (CheckCubeEuler(270f, 180f, 0f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * 90f * inverted));
                else
                    StartCoroutine(RotateEase(direction3 * -90f * invertedOnTopWall * invertedOnBackWall));

            }
            else
            // Cuando ha rotado z en 90º
            if (CheckCubeEuler(0f, 0f, 90f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * 90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(0f, 270f, 90f))
            {

                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * 90f * inverted));
                else
                    StartCoroutine(RotateEase(direction1 * -90f * invertedOnTopWall * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(0f, 180f, 90f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * 90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(0f, 90f, 90f))
            {
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * 90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else
                    StartCoroutine(RotateEase(direction1 * 90f * invertedOnBackWall));
                Debug.Log("a");
            }

            // rotado x en 90
            else
            if (CheckCubeEuler(90f, 90f, 0f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * -90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * -90f));

                else
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(0f, 270f, 180f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * -90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction1 * 90f));

                else
                    StartCoroutine(RotateEase(direction1 * -90f * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(270f, 90f, 0f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * 90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * 90f));

                else
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));

            }
            else
            if (CheckCubeEuler(0f, 90f, 0f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * 90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else
                    StartCoroutine(RotateEase(direction1 * 90f * invertedOnBackWall));
            }

            else
            if (CheckCubeEuler(90f, 270f, 0f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * -90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * 90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f * invertedOnBackWall));

            }
            else
            if (CheckCubeEuler(0f, 90f, 180f))
            {

                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * -90f * inverted));
                else if (playerOnTopWallLookingRightLeft || playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else
                    StartCoroutine(RotateEase(direction1 * 90f * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(270f, 270f, 0f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction1 * 90f * inverted));
                else if (playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else
                    StartCoroutine(RotateEase(direction2 * 90f * invertedOnBackWall));

            }
            else
            if (CheckCubeEuler(0f, 270f, 0f))
            {
                Debug.Log("a");
                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction2 * 90f * inverted));
                else if (playerOnTopWallLookingRightLeft || playerOnTopWallLookingBackFront)
                    StartCoroutine(RotateEase(direction1 * 90f));
                else
                    StartCoroutine(RotateEase(direction1 * -90f * invertedOnBackWall));
            }
            else
            if (CheckCubeEuler(0f, 180f, 270f))
            {
                Debug.Log("a");
                if (playerOnFrontWall)
                    StartCoroutine(RotateEase(direction2 * -90f));
                else
                    StartCoroutine(RotateEase(direction3 * -90f));
            }
            else
            if (CheckCubeEuler(0f, 270f, 270f))
            {
                Debug.Log("a");

                if (playerOnRightWallCond || playerOnLeftWallCond)
                    StartCoroutine(RotateEase(direction3 * -90f * inverted));
                else if (playerOnFrontWall)
                    StartCoroutine(RotateEase(direction1 * -90f));
                else
                    StartCoroutine(RotateEase(direction2 * -90f));
            }
        }

    }

    private bool CheckCubeEuler(float x, float y, float z)
    {
        if (transform.eulerAngles.x < 0f && transform.eulerAngles.x > -1f)
            x = 360f;
        if (transform.eulerAngles.y < 0f && transform.eulerAngles.y > -1f)
            y = 360f;
        if (transform.eulerAngles.z < 0f && transform.eulerAngles.z > -1f)
            z = 360f;

        return ((int)Math.Round(transform.eulerAngles.x, MidpointRounding.AwayFromZero) == x && (int)Math.Round(transform.eulerAngles.y, MidpointRounding.AwayFromZero) == y && (int)Math.Round(transform.eulerAngles.z, MidpointRounding.AwayFromZero) == z);
    }


    IEnumerator RotateEase(Vector3 direction)
    {
        var startRotation = transform.rotation;
        var endRotation = transform.rotation * Quaternion.Euler(direction);
        float t = 0.0f;
        rotating = true;
        IsRotating = true;
        float rate = 1.0f / rotationSpeed;
        player.SetParent(transform);

        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            transform.rotation = Quaternion.Slerp(
                startRotation,
                endRotation,
                Mathf.SmoothStep(0.0f, 1.0f, t)
            );


            yield return null;
        }

        // Corrige los grados
        transform.eulerAngles = insideGrades();
        IsRotating = false;
        rotating = false;
        player.parent = null;
    }

    // Comprueba que los grados son exactamente 0 90 180 270
    private Vector3 insideGrades()
    {
        int x = correctedGrade(transform.eulerAngles.x);
        int y = correctedGrade(transform.eulerAngles.y);
        int z = correctedGrade(transform.eulerAngles.z);

        return new Vector3(x, y, z);
    }

    // Corrige los grados a 0 90 180 70
    private int correctedGrade(float angle)
    {
        if (angle > 45 && angle <= 135)
            return 90;
        if (angle > 135 && angle <= 235)
            return 180;
        if (angle > 235 && angle <= 315)
            return 270;
        return 0;
    }

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 140, 150), "Loader Menu");
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        GUI.TextArea(new Rect(20, 65, 120, 20), playerLookingAtInteriorWall);
        GUI.TextArea(new Rect(20, 85, 120, 20), playerOnWall);

    }

}
