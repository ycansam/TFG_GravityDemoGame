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
    private Transform wallsHelper;

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

    private String playerLookingAtWall = "";

    void Update()
    {
        Controls();
        CheckPlayerLookingAt();
        if (player.parent == null)
        {
            wallsHelper.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            wallsHelper.GetChild(0).gameObject.SetActive(false);
        }
        // if (playerLookingAtWall.Contains("Top") || playerLookingAtWall.Contains("Interior"))
        // {
        //     wallsHelper.GetChild(0).gameObject.SetActive(true);
        // }
        // else
        // {
        //     wallsHelper.GetChild(0).gameObject.SetActive(false);
        // }
    }


    private void CheckPlayerLookingAt()
    {
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 50;
        Debug.DrawRay(playerHead.position, forward, Color.green);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(playerHead.position, forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {

            RaycastHit hit = hits[i];
            if (hit.transform.gameObject.name.Contains("Wall"))
            {


                playerLookingAtWall = hit.transform.gameObject.name;
                // Debug.Log(playerLookingAtWall);
            }
        }
    }

    private void Controls()
    {

        if (playerLookingAtWall.Contains("Front"))
            RotateCubeByLookingAtAnyWall(transform.forward, transform.up, transform.right);
        else if (playerLookingAtWall.Contains("Right"))
            RotateCubeByLookingAtAnyWall(transform.forward, transform.up, transform.right, KeyCode.R, KeyCode.E);
        else if (playerLookingAtWall.Contains("Backward"))
            RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up * -1, transform.right * -1);
        else if (playerLookingAtWall.Contains("Left"))
            RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up * -1, transform.right * -1, KeyCode.R, KeyCode.E);
        else if (playerLookingAtWall.Contains("Inferior"))
            RotateCubeByLookingAtAnyWall(transform.forward * -1, transform.up * -1, transform.right * -1, KeyCode.R, KeyCode.E);
        else if (playerLookingAtWall.Contains("Top"))
            RotateCubeByLookingAtAnyWall(transform.forward, transform.up, transform.right, KeyCode.R, KeyCode.E);
    }


    // direction 1 forward, direction 2 up, direction 3 right
    private void RotateCubeByLookingAtAnyWall(Vector3 direction1, Vector3 direction2, Vector3 direction3,
     KeyCode rightKey = KeyCode.E, KeyCode frontKey = KeyCode.R
     )
    {
        if (Input.GetKeyDown(rightKey) && !rotating)
        {
            if (Math.Round(transform.eulerAngles.x) == 0f && Math.Round(transform.eulerAngles.y) == 0f)
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            if (Math.Round(transform.eulerAngles.x) == 0f && Math.Round(transform.eulerAngles.y) == 0f && Math.Round(transform.eulerAngles.z) != 0f)
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            else if (CheckCubeEuler(90f, 0f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            else if (CheckCubeEuler(90f, 90f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * 90f));
            else if (CheckCubeEuler(90f, 180f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            else if (CheckCubeEuler(90f, 270f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));

            if (CheckCubeEuler(0f, 180f, 180f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            else if (CheckCubeEuler(0f, 180f, 270f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            else if (CheckCubeEuler(0f, 180f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            else if (CheckCubeEuler(0f, 180f, 90f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));

            if (CheckCubeEuler(270f, 0f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            else if (CheckCubeEuler(270f, 90f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));
            else if (CheckCubeEuler(270f, 180f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            else if (CheckCubeEuler(270f, 270f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * 90f));


            if (CheckCubeEuler(0f, 90f, 90f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            else if (CheckCubeEuler(0f, 90f, 180f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * 90f));
            else if (CheckCubeEuler(0f, 90f, 270f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            else if (CheckCubeEuler(0f, 90f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));

            if (CheckCubeEuler(0f, 270f, 270f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            else if (CheckCubeEuler(0f, 270f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * 90f));
            else if (CheckCubeEuler(0f, 270f, 90f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            else if (CheckCubeEuler(0f, 270f, 180f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));

        }

        if (Input.GetKeyDown(frontKey) && !rotating)
        {
            if (Math.Round(transform.eulerAngles.z) == 0 && Math.Round(transform.eulerAngles.y) == 0)
                StartCoroutine(RotateEase(rotationSpeed, direction3 * 90f));
            else if (Math.Round(transform.eulerAngles.z) == 180f && Math.Round(transform.eulerAngles.y) == 180f)
            {
                StartCoroutine(RotateEase(rotationSpeed, direction3 * 90f));
            }

            // Cuando ha rotado z en 270º
            if (CheckCubeEuler(0f, 0f, 270f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            if (CheckCubeEuler(0f, 270f, 270f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            if (CheckCubeEuler(0f, 180f, 270f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            if (CheckCubeEuler(0f, 90f, 270f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * 90f));


            // Cuando ha rotado z en 180º
            if (CheckCubeEuler(0f, 0f, 180f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));
            if (CheckCubeEuler(90f, 180f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));
            if (CheckCubeEuler(0f, 180f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));
            if (CheckCubeEuler(270f, 180f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction3 * -90f));

            // Cuando ha rotado z en 90º
            if (CheckCubeEuler(0f, 0f, 90f))
            {
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            }
            if (CheckCubeEuler(0f, 270f, 90f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            if (CheckCubeEuler(0f, 180f, 90f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            if (CheckCubeEuler(0f, 90f, 90f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * 90f));

            // rotado x en 90
            if (CheckCubeEuler(90f, 90f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            if (CheckCubeEuler(0f, 270f, 180f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));
            if (CheckCubeEuler(270f, 90f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            if (CheckCubeEuler(0f, 90f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * 90f));

            if (CheckCubeEuler(90f, 270f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * -90f));
            if (CheckCubeEuler(0f, 90f, 180f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * 90f));
            if (CheckCubeEuler(270f, 270f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction2 * 90f));
            if (CheckCubeEuler(0f, 270f, 0f))
                StartCoroutine(RotateEase(rotationSpeed, direction1 * -90f));

        }


        if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        {
            if (Math.Round(transform.eulerAngles.y) == 0 && Math.Round(transform.eulerAngles.y) == 0)
            {
                StartCoroutine(RotateEase(rotationSpeed, direction1 * 90f));
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


    IEnumerator RotateEase(float duration, Vector3 direction)
    {
        var startRotation = transform.rotation;
        var endRotation = transform.rotation * Quaternion.Euler(direction);
        float t = 0.0f;
        rotating = true;
        IsRotating = true;
        float rate = 1.0f / duration;



        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            transform.rotation = Quaternion.Slerp(
                startRotation,
                endRotation,
                Mathf.SmoothStep(0.0f, 1.0f, t)
            );

            // if (player.parent == null)
            // {
            wallsHelper.rotation = Quaternion.Slerp(
                            startRotation,
                            endRotation,
                            Mathf.SmoothStep(0.0f, 1.0f, t)
                        );
            // }


            yield return null;
        }

        // Corrige los grados
        transform.eulerAngles = insideGrades();
        IsRotating = false;
        rotating = false;
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
        int v = 0;

        if (angle > -10 || angle > 315 && angle <= 45)
            v = 0;
        if (angle > 45 && angle <= 135)
            v = 90;
        if (angle > 135 && angle <= 235)
            v = 180;
        if (angle > 235 && angle <= 315)
            v = 270;

        return v;
    }
    void OnGUI()
    {
        GUILayout.Button(playerLookingAtWall);
    }

}
