using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;

    // Booleano que inidica si esta en un lado u otro
    [SerializeField]
    private bool neg;

    private void OnTriggerStay(Collider other)
    {
        GameObject objectToTp = other.gameObject;
        if (other.tag != Tags.PLAYER)
        {

            float distance = 0.2f;
            Vector3 playerFromPortal = transform.position - objectToTp.transform.position;
            // si es negativo 
            if (!neg)
            {
                if (playerFromPortal.x <= -distance)
                {
                    objectToTp.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                }
            }
            else
            {
                //  || playerFromPortal.y >= -distance || playerFromPortal.z >= -distance
                if (playerFromPortal.x >= -distance)
                    objectToTp.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
        }
    }
}
