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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!other.gameObject.name.Contains("Clone"))
            {
                bool objectHasEnteredFromBack = ObjectHasExitedFromBack(other.gameObject);
                // Debug.Log("ENTER: " + objectHasEnteredFromBack);
                other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack = objectHasEnteredFromBack;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject objectToTp = other.gameObject;
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            bool exitedFromBack = ObjectHasExitedFromBack(objectToTp);
            Vector3 objectFromPortal = transform.position - objectToTp.transform.position;

            if (!exitedFromBack)
            {
                if (!other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack)
                {
                    // NO HACER NADA SE QUEDAAAAAAAAAAAAA! :D
                }
                else
                {
                    // PASA AL PORTAL DESDE LA SALIDA :DDDDDD
                    Debug.Log("pasa al otro lado desde la salida");
                    objectToTp.transform.position = exitPortal.position - new Vector3(objectFromPortal.x, objectFromPortal.y, objectFromPortal.z);
                }
            }
            else
            {
                if (!other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack)
                {
                    // PASA AL PORTAL DESDE LA ENTRADA UUUU :)()
                    objectToTp.transform.position = otherPortal.position - new Vector3(objectFromPortal.x, objectFromPortal.y, objectFromPortal.z);
                    Debug.Log("pasa al otro lado desde la entrada");
                }
                else
                {
                    // NO HACE NADA SE QUEDAAAAAAAA JIJI POR DETRÁS
                }
            }

            // Debug.Log("EXIT: " + exitedFromBack);
            // Debug.Log("OBJECT PROPERTY ENTERED:" + other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack);
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
