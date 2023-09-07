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
    public float velocidadRotacion = 1.0f;
    public bool IsRotating
    {
        get { return this.isRotating; }
        private set { this.isRotating = value; }
    }

    [SerializeField]
    private float rotationSpeed = 1f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        playerInCube = GetComponentInChildren<PlayerInCube>();
    }

    private void Update()
    {

    }


    public void RotateSmooth(Vector3 direction)
    {
        if (!isRotating)
            StartCoroutine(RotateEase(direction));
    }
    float anguloRotado = 0.0f;

    private IEnumerator RotateEase(Vector3 direction)
    {
        InitVariablesBeforeRotate();
        while (anguloRotado < 90.0f)
        {
            float anguloRotacion = velocidadRotacion * 90f * Time.deltaTime;
            transform.Rotate(direction, anguloRotacion, Space.World);
            anguloRotado += anguloRotacion;
            yield return null;
        }

        // Corrige los grados
        transform.eulerAngles = insideGrades(transform);
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
        anguloRotado = 0;
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
