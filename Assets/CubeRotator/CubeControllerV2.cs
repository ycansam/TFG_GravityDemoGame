using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeControllerV2 : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    [SerializeField]
    private PlayerInCube playerInCube;
    [SerializeField]
    private Transform refCubeRotation;

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
    void Update()
    {
        Controls();
    }

    private void Controls()
    {
        if (Input.GetKeyDown(keyRight))
        {
            StartCoroutine(RotateEase(new Vector3(1f, 0f, 0f)));
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
        refCubeRotation.rotation = transform.rotation;
        Vector3 startRotation = refCubeRotation.eulerAngles;
        refCubeRotation.Rotate(direction * 90f, Space.World);
        refCubeRotation.eulerAngles = insideGrades(refCubeRotation);
        Vector3 endRotation = refCubeRotation.eulerAngles;

        // float t = 0.0f;
        // float rate = 1.0f / rotationSpeed;
        //     t += Time.deltaTime * rate;
        while ((int)transform.eulerAngles.x != endRotation.x || (int)transform.eulerAngles.y != endRotation.y || (int)transform.eulerAngles.z != endRotation.z)
        {
            transform.Rotate(direction, Space.World);
            yield return null;
        }

        ResetVariablesAfterRotate();
        // Corrige los grados
        transform.eulerAngles = insideGrades(transform);
    }

    private void InitVariablesBeforeRotate()
    {
        rotating = true;
        IsRotating = true;
        if (playerInCube.isPlayerOnCube())
            player.SetParent(transform);
    }

    private void ResetVariablesAfterRotate()
    {
        IsRotating = false;
        rotating = false;
        player.parent = null;
    }


    // Comprueba que los grados son exactamente 0 90 180 270
    private Vector3 insideGrades(Transform tr)
    {
        int x = correctedGrade(tr.eulerAngles.x);
        int y = correctedGrade(tr.eulerAngles.y);
        int z = correctedGrade(tr.eulerAngles.z);

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
}
