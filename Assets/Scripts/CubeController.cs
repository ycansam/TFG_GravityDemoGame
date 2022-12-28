using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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

    private String playerLookingAtWall = "";

    void Update()
    {
        Controls();
        CheckPlayerLookingAt();
    }


    private void CheckPlayerLookingAt()
    {
        Vector3 forward = player.TransformDirection(Vector3.forward) * 50;
        Debug.DrawRay(player.position, forward, Color.green);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(player.position, forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.transform.gameObject.name.Contains("Wall"))
            {
                playerLookingAtWall = hit.transform.gameObject.name;
                Debug.Log(playerLookingAtWall);
            }
        }
    }

    private void Controls()
    {

        if (playerLookingAtWall.Contains("Front"))
            RotateLookingForwardWall();
        else if (playerLookingAtWall.Contains("Right"))
            RotateLookingRightWall();
        else if (playerLookingAtWall.Contains("Backward"))
            RotateLookingBackwardWall();
        else if (playerLookingAtWall.Contains("Left"))
            RotateLookingLeftWall();

    }

    private void RotateLookingForwardWall()
    {

        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            if (transform.eulerAngles.x == 0 && transform.eulerAngles.y == 0)
                StartCoroutine(RotateEase(rotationSpeed, transform.forward * -90f));
        }

        if (Input.GetKeyDown(KeyCode.R) && !rotating)
        {
            if (Math.Round(transform.eulerAngles.z) == 0 && Math.Round(transform.eulerAngles.y) == 0)
                StartCoroutine(RotateEase(rotationSpeed, transform.right * 90f));
            else if (Math.Round(transform.eulerAngles.z) == 270f &&  Math.Round(transform.eulerAngles.y) == 0)
            {
                StartCoroutine(RotateEase(rotationSpeed, transform.up * 90f));
            }
            else if (Math.Round(transform.eulerAngles.z) == 270f &&  Math.Round(transform.eulerAngles.y) == 270f)
            {
                StartCoroutine(RotateEase(rotationSpeed, transform.forward * -90f));
            }
            else if (Math.Round(transform.eulerAngles.z) == 270f &&  Math.Round(transform.eulerAngles.y) == 180f)
            {
                StartCoroutine(RotateEase(rotationSpeed, transform.up * -90f));
            }
            else if (Math.Round(transform.eulerAngles.z) == 270f && Math.Round(transform.eulerAngles.y) == 90f)
            {
                StartCoroutine(RotateEase(rotationSpeed, transform.forward * 90f));
            }
        }

        Debug.Log(transform.eulerAngles);

        // if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        // {
        //     if (transform.rotation.x == 0 && transform.rotation.y == 0)
        //         StartCoroutine(RotateEase(rotationSpeed, transform.forward * 90f));
        // }

        // if (Input.GetKeyDown(KeyCode.F) && !rotating)
        // {
        //     if (transform.rotation.z == 0 && transform.rotation.y == 0)
        //         StartCoroutine(RotateEase(rotationSpeed, transform.right * -90f));
        // }
    }

    private void RotateLookingRightWall()
    {
        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.right * -90f));
        }
        if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.right * 90f));
        }
    }
    private void RotateLookingBackwardWall()
    {
        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.forward * -1 * -90f));
        }
        if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.forward * -1 * 90f));
        }
    }

    private void RotateLookingLeftWall()
    {
        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.right * -1 * -90f));
        }
        if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        {
            StartCoroutine(RotateEase(rotationSpeed, transform.right * -1 * 90f));
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
}
