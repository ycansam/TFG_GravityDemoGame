using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectDuplicator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform enterPortal;
    [SerializeField]
    private Transform inversePortal;

    private List<GameObject> duplicatedEnterObjects = new List<GameObject>();
    private List<GameObject> duplicatedInverseObjects = new List<GameObject>();


    private List<GameObject> enterPortalObjects = new List<GameObject>();
    private List<GameObject> inversePortalObjects = new List<GameObject>();

    private void FixedUpdate()
    {
        PasteObjectPositionInOtherPortal();
    }

    private void PasteObjectPositionInOtherPortal()
    {
        for (int i = 0; i < enterPortalObjects.Count; i++)
        {
            Vector3 objectFromPortal = transform.position - duplicatedEnterObjects[i].transform.position;
            enterPortalObjects[i].transform.position = enterPortal.position - new Vector3(objectFromPortal.x, objectFromPortal.y, objectFromPortal.z);
            enterPortalObjects[i].transform.rotation = duplicatedEnterObjects[i].transform.rotation;
            // enterPortalObjects[i].transform.localScale = duplicatedEnterObjects[i].transform.localScale;
        }
        for (int i = 0; i < inversePortalObjects.Count; i++)
        {
            Vector3 objectFromPortal = transform.position - duplicatedInverseObjects[i].transform.position;
            inversePortalObjects[i].transform.position = inversePortal.position - new Vector3(objectFromPortal.x, objectFromPortal.y, objectFromPortal.z);
            inversePortalObjects[i].transform.rotation = duplicatedInverseObjects[i].transform.rotation;
            // inversePortalObjects[i].transform.localScale = duplicatedInverseObjects[i].transform.localScale;

        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!duplicatedEnterObjects.Contains(other.gameObject))
            {
                if (!other.name.Contains("Clone") && !other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack)
                {
                    GameObject instanceOfObject = Instantiate(other.gameObject, other.transform.position, Quaternion.identity) as GameObject;
                    instanceOfObject.transform.name = instanceOfObject.transform.name + ": " + transform.name;
                    instanceOfObject.transform.SetParent(enterPortal.parent);
                    enterPortalObjects.Add(instanceOfObject);

                    Destroy(instanceOfObject.GetComponent<Gravity>());
                    duplicatedEnterObjects.Add(other.gameObject);
                    other.gameObject.GetComponent<ObjectProperties>().isTeleporting = true;
                    instanceOfObject.GetComponent<ObjectProperties>().isTeleporting = true;
                }

            }

            if (!duplicatedInverseObjects.Contains(other.gameObject))
                if (!other.name.Contains("Clone") && other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack)
                {
                    GameObject instanceOfObject = Instantiate(other.gameObject, other.transform.position, Quaternion.identity) as GameObject;

                    instanceOfObject.transform.name = instanceOfObject.transform.name + ": " + transform.name;
                    instanceOfObject.transform.SetParent(inversePortal.parent);
                    inversePortalObjects.Add(instanceOfObject);

                    Destroy(instanceOfObject.GetComponent<Gravity>());
                    duplicatedInverseObjects.Add(other.gameObject);
                    other.gameObject.GetComponent<ObjectProperties>().isTeleporting = true;
                    instanceOfObject.GetComponent<ObjectProperties>().isTeleporting = true;
                }


            DisableCollidersFromEachOther(other.gameObject);

        }
    }

    private void DisableCollidersFromEachOther(GameObject ob)
    {
        if (duplicatedEnterObjects.Contains(ob))
        {
            foreach (GameObject go in duplicatedInverseObjects)
            {
                Physics.IgnoreCollision(ob.GetComponent<Collider>(), go.GetComponent<Collider>(), true);
            }
        }
        else
        {
            foreach (GameObject go in duplicatedInverseObjects)
            {
                Physics.IgnoreCollision(ob.GetComponent<Collider>(), go.GetComponent<Collider>(), false);
            }
        }
        if (duplicatedInverseObjects.Contains(ob))
        {
            foreach (GameObject go in duplicatedEnterObjects)
            {
                Physics.IgnoreCollision(ob.GetComponent<Collider>(), go.GetComponent<Collider>(), true);
            }
        }
        else
        {
            foreach (GameObject go in duplicatedEnterObjects)
            {
                Physics.IgnoreCollision(ob.GetComponent<Collider>(), go.GetComponent<Collider>(), false);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (duplicatedEnterObjects.Contains(other.gameObject))
            {
                int index = duplicatedEnterObjects.IndexOf(other.gameObject);
                if (index != -1)
                {
                    duplicatedEnterObjects.RemoveAt(index);

                    GameObject duplicated = enterPortalObjects[index];
                    enterPortalObjects.RemoveAt(index);
                    Destroy(duplicated);

                    other.gameObject.GetComponent<ObjectProperties>().isTeleporting = false;
                }
            }
            if (duplicatedInverseObjects.Contains(other.gameObject))
            {
                int index = duplicatedInverseObjects.IndexOf(other.gameObject);
                if (index != -1)
                {
                    duplicatedInverseObjects.RemoveAt(index);
                    GameObject duplicated = inversePortalObjects[index];
                    inversePortalObjects.RemoveAt(index);
                    Destroy(duplicated);
                    other.gameObject.GetComponent<ObjectProperties>().isTeleporting = false;
                }
            }
        }
    }
}