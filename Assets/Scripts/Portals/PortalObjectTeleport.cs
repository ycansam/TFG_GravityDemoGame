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

    private void OnTriggerExit(Collider other)
    {
        GameObject objectToTp = other.gameObject;
        if (other.tag != Tags.PLAYER)
        {

            Vector3 playerFromPortal = transform.position - objectToTp.transform.position;
            // si es negativo 
            if (!neg)
            {
                Debug.Log(playerFromPortal);
                objectToTp.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
            else
            {
                objectToTp.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
        }
    }
}
