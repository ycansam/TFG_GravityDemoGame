using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallController : MonoBehaviour
{
    [SerializeField]
    private Transform playerHead;

    [SerializeField]
    private GameObject markerPrefab;

    private GameObject marker;
    private RaycastHit hit;
    private RaycastHit hitHelpWall;
    private RaycastHit actualPlayerStandingWall;

    private string playerOnWall;


    // Start is called before the first frame update
    void Start()
    {
        marker = Instantiate<GameObject>(markerPrefab);
        marker.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        LookingForwardRay();
        Controls();
    }

    private void Controls()
    {
        Debug.Log(transform.localEulerAngles);
        if (Input.GetKeyDown(KeyCode.X) && marker.activeSelf)
        {
            RotatePlayerByWall(CharacterWallsInformation.GetCharOnWallHelpName());
        }
    }

    private void RotatePlayerByWall(string wallName)
    {
        Debug.Log(wallName);
        if (wallName.Contains("Inferior"))
        {
            float fixedY = FixRotationToInt(transform.localEulerAngles.y);
            // transform.eulerAngles = new Vector3(transform.localEulerAngles.x - 90f, transform.localEulerAngles.y - fixedY, transform.localEulerAngles.z);
            transform.Rotate(new Vector3(-90f, 0f - fixedY, 0f), Space.Self);
            Debug.Log(transform.eulerAngles);
            Debug.Log(transform.localEulerAngles);
        }
        else if (wallName.Contains("Right") || wallName.Contains("Front") || wallName.Contains("Left") || wallName.Contains("Back"))
        {
            if (transform.localEulerAngles.x > 300f && transform.localEulerAngles.x <= 360f || transform.localEulerAngles.x > 0f && transform.localEulerAngles.x <= 60f)
            {
                transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 90f, transform.localEulerAngles.z);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 90f, transform.localEulerAngles.z);
            }
        }

    }

    private float FixRotationToInt(float axisAngle)
    {
        int timesError = (int)(axisAngle / 90f);
        Debug.Log(timesError);

        Debug.Log(axisAngle % 90f);
        float error = axisAngle % 90f;

        if (axisAngle > 45f && axisAngle < 90f || axisAngle >= 135f && axisAngle < 180f || axisAngle >= 225f && axisAngle < 270f)
        {
            float newError = 90f - error;
            return -newError;
        }
        return error;
        // Debug.Log(axisAngle - timesError * 90f);
    }

    private void LookingForwardRay()
    {
        // Crea el rayo y lo debugea
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 4F;
        Debug.DrawRay(playerHead.position, forward, Color.yellow);

        AssignMarkerPoint(Physics.RaycastAll(playerHead.position, forward, 4.0F));
    }

    // Asigna al marker un punto donde estar y aparecer
    private void AssignMarkerPoint(RaycastHit[] hits)
    {

        // Activa el marcador si tiene puntos detectados en el rayo
        ActiveMarker(hits.Length > 0);

        for (int i = 0; i < hits.Length; i++)
        {
            hit = hits[i];
            if (CharacterWallsInformation.IsRayHittingWall(hit))
                marker.transform.position = hit.point;
        }
    }

 

    // Activa o desactiva el marcador dependiendo de la condicion
    private void ActiveMarker(bool activationCond)
    {
        if (!marker.activeSelf && activationCond)
            marker.SetActive(true);
        else if (marker.activeSelf && !activationCond)
            marker.SetActive(false);
    }
   

}
