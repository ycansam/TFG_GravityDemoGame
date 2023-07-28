using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRays : MonoBehaviour
{
    [SerializeField] private Transform playerHead;

    public RaycastHit[] GetForwardRayHits()
    {
        // Crea el rayo y lo debugea
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 50;
        Debug.DrawRay(playerHead.position, forward, Color.green);
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
        return Physics.RaycastAll(playerHead.position, forward, 50.0F); ;
    }
    public RaycastHit GetFirstForwardRayHit()
    {
        Vector3 forward = playerHead.TransformDirection(Vector3.forward);
        Ray ray = new Ray(playerHead.position, forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50.0f, 9, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawRay(playerHead.position, forward * hit.distance, Color.green);
            return hit;
        }

        return default(RaycastHit);
    }

}
