using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform portal;
    public Transform otherPortal;

    public bool neg;
    private Transform player_cam;
    private void Start()
    {
        player_cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void LateUpdate()
    {

        if (!neg)
        {
            Vector3 playerOffsetFromPrtal = player_cam.position - otherPortal.position;
            transform.position = portal.position + playerOffsetFromPrtal;
        }
        else
        {
            Vector3 playerOffsetFromPrtal = player_cam.position + otherPortal.position;
            transform.position = -portal.position + playerOffsetFromPrtal;

        }
        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        // Vector3 newCamDir = player_cam.forward;

        // transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);
        transform.rotation = player_cam.rotation;


        /*   Matrix4x4 m = portal.localToWorldMatrix * otherPortal.localToWorldMatrix * player_cam.localToWorldMatrix;

           portal_cam.SetPositionAndRotation(m.GetColumn(3), m.rotation);*/

    }
}
