using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalCamera : MonoBehaviour
{
    [SerializeField]
    private List<Transform> portalCameras = new List<Transform>();
    private List<GameObject> includedObjects = new List<GameObject>();


    private void IncludeMovableIfNotIncluded(GameObject ob)
    {
        if (!includedObjects.Contains(ob))
        {
            includedObjects.Add(ob);
        }
    }
    private void RemoveMovableIfIncluded(GameObject ob)
    {
        if (includedObjects.Contains(ob))
        {
            int index = includedObjects.IndexOf(ob);
            includedObjects.RemoveAt(index);
        }
    }

    private void DisableObjectRenders()
    {
        foreach (GameObject ob in includedObjects)
        {
            ob.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void EnableObjectRenders()
    {
        foreach (GameObject ob in includedObjects)
        {
            ob.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            IncludeMovableIfNotIncluded(other.gameObject);
        }

        foreach (Transform portalCamera in portalCameras)
        {
            if (other.name == portalCamera.name)
            {
                DisableObjectRenders();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            RemoveMovableIfIncluded(other.gameObject);
        }

        foreach (Transform portalCamera in portalCameras)
        {
            if (other.name == portalCamera.name)
            {
                EnableObjectRenders();
            }
        }

    }
}
