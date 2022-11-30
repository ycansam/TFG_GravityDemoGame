using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
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
    private float rotationSpeed = 1f;
    bool rotating = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            if (transform.rotation.x == 0 && transform.rotation.y == 0)
                StartCoroutine(RotateEase(rotationSpeed, transform.forward * -90f));
        }
        if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        {
            if (transform.rotation.x == 0 && transform.rotation.y == 0)
                StartCoroutine(RotateEase(rotationSpeed, transform.forward * 90f));
        }
        if (Input.GetKeyDown(KeyCode.R) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.right * 90f));
        }
        if (Input.GetKeyDown(KeyCode.F) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.right * -90f));
        }
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
            yield return null;
        }
        IsRotating = false;
        rotating = false;
    }

    // void GetPlayerInputs() { }

    // IEnumerator Rotate(float duration)
    // {
    //     float startRotation = transform.eulerAngles.z;
    //     float endRotation = startRotation + 90.0f;
    //     float t = 0.0f;
    //     while (t < duration)
    //     {
    //         t += Time.deltaTime;
    //         float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
    //         transform.eulerAngles = new Vector3(
    //             transform.eulerAngles.x,
    //             transform.eulerAngles.y,
    //             yRotation
    //         );
    //         yield return null;
    //     }
    // }
}
