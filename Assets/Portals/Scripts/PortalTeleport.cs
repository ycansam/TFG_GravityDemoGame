using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;

    [SerializeField]
    private Transform exitPortal;

    [SerializeField]
    private Transform enterPoint;

    [SerializeField]
    private Transform exitPoint;

    // Booleano que inidica si esta en un lado u otro
    [SerializeField]
    private bool neg;
    private Transform player;

    private static float firstContactPoint = 0;
    private bool teleporting = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == Tags.PLAYER)
        {

            float distance = 0.001f;
            teleporting = true;
            Vector3 playerFromPortal = transform.position - player.position;
            float playerFromPortalDistance = GetPlayerFromPortalDistance();
            if (firstContactPoint == 0)
            {
                firstContactPoint = playerFromPortalDistance;
            }
            // si es negativo 
            if (!neg)
            {
                if (firstContactPoint > 0)
                {
                    if (playerFromPortalDistance > -distance)
                    {
                        Debug.Log("a1");
                        player.transform.position = exitPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                    }
                }
                else if (firstContactPoint < 0)
                {
                    if (playerFromPortalDistance > -distance)
                    {
                        Debug.Log("a2");
                        player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                    }
                }
            }
            else
            {
                if (firstContactPoint > 0)
                {
                    if (playerFromPortalDistance > -distance)
                    {
                        Debug.Log("b1");
                        player.transform.position = exitPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                    }
                }
                else if (firstContactPoint < 0)
                {
                    if (playerFromPortalDistance > -distance)
                    {
                        Debug.Log("b2");
                        player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                    }
                }

            }
        }
    }

    private float GetPlayerFromPortalDistance()
    {

        Vector3 objectFromEntryPoint = enterPoint.position - player.transform.position;
        Vector3 objectFromExitPoint = exitPoint.position - player.transform.position;
        float distance = objectFromEntryPoint.magnitude - objectFromExitPoint.magnitude;
        return distance;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            firstContactPoint = 0;
            teleporting = false;
        }
    }

}
