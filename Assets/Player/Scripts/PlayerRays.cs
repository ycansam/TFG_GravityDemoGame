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

}
