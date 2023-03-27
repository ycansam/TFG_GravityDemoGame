using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectTeleport : MonoBehaviour
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

    private void OnTriggerExit(Collider other)
    {
        GameObject objectToTp = other.gameObject;
        if (other.tag != Tags.PLAYER)
        {


            bool exitedFromBack = GetFromWhereIsTheObjectExiting(objectToTp);
            if (exitedFromBack == neg)
            {
                Vector3 playerFromPortal = transform.position - objectToTp.transform.position;
                objectToTp.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);

            }
        }
    }

    // true si ha salido por detras del portal, false si ha salido por delante
    private bool GetFromWhereIsTheObjectExiting(GameObject objectToTp)
    {

        Vector3 objectFromEntryPoint = enterPoint.position - objectToTp.transform.position;
        Vector3 objectFromExitPoint = exitPoint.position - objectToTp.transform.position;
        float direction = objectFromEntryPoint.magnitude - objectFromExitPoint.magnitude;
        if (direction > 0)
            return true;
        return false;
    }

}
