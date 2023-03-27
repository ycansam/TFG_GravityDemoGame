using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;
    [SerializeField]
    private Transform enterPoint;

    [SerializeField]
    private Transform exitPoint;

    // Booleano que inidica si esta en un lado u otro
    [SerializeField]
    private bool neg;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == Tags.PLAYER)
        {

            float distance = 0.02f;
            Vector3 playerFromPortal = transform.position - player.position;
            float playerFromPortalDistance = GetPlayerFromPortalDistance();
            // si es negativo 

            if (!neg)
            {
                if (playerFromPortalDistance <= -distance)
                {
                    Debug.Log('X');
                    player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                }

            }
            else
            {
                if (playerFromPortalDistance >= -distance)
                    player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
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

}
