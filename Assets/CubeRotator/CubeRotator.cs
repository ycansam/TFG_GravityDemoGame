using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeRotator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
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
    private float rotationSpeed = 1f;

    public float velocidadRotacion = 1f; // Velocidad de rotación en grados por segundo
    private float anguloRotado = 0.0f;
    Vector3 directionToRotate;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        playerInCube = GetComponentInChildren<PlayerInCube>();
    }

    private void Update()
    {
        if (isRotating)
        {
            if (anguloRotado < 90.0f)
            {
                float anguloRotacion = velocidadRotacion * 90f * Time.deltaTime;
                transform.Rotate(directionToRotate, anguloRotacion, Space.World);
                anguloRotado += anguloRotacion;
            }
            else
            {
                isRotating = false;
            }
        }
        else
        {
            anguloRotado = 0;
            transform.eulerAngles = insideGrades(transform);

            ResetVariablesAfterRotate();
        }

    }


    public void RotateSmooth(Vector3 direction)
    {
        Debug.Log("ROTANDO");
        if (!isRotating)
        {
            InitVariablesBeforeRotate();
            directionToRotate = direction;
            // StartCoroutine(RotateEase(direction));
        }
    }

    private IEnumerator RotateEase(Vector3 direction)
    {
        InitVariablesBeforeRotate();
        refCubeRotation.rotation = transform.rotation;
        refCubeRotation.Rotate(direction * 90f, Space.World);
        yield return null;
        ResetVariablesAfterRotate();
    }

    private void InitVariablesBeforeRotate()
    {
        if (playerInCube.isPlayerOnCube())
            player.parent = transform;
        IsRotating = true;
    }

    private void ResetVariablesAfterRotate()
    {
        IsRotating = false;
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
