using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectTeleport : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!other.gameObject.name.Contains("Clone"))
            {
                bool objectHasEnteredFromBack = ObjectHasExitedFromBack(other.gameObject);
                other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack = objectHasEnteredFromBack;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject objectToTp = other.gameObject;
        if (other.tag != Tags.PLAYER)
        {

            bool exitedFromBack = ObjectHasExitedFromBack(objectToTp);
            Vector3 playerFromPortal = transform.position - objectToTp.transform.position;
            if (exitedFromBack == neg)
            {
                objectToTp.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
            else
            {
                objectToTp.transform.position = exitPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
        }
    }

    // true si ha salido por detras del portal, false si ha salido por delante
    private bool ObjectHasExitedFromBack(GameObject objectToTp)
    {

        Vector3 objectFromEntryPoint = enterPoint.position - objectToTp.transform.position;
        Vector3 objectFromExitPoint = exitPoint.position - objectToTp.transform.position;
        float direction = objectFromEntryPoint.magnitude - objectFromExitPoint.magnitude;
        if (direction > 0)
            return true;
        return false;
    }

}
