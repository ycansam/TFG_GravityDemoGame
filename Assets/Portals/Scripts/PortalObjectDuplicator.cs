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

    private List<GameObject> duplicatedObjects = new List<GameObject>();
    private List<GameObject> enterPortalObjects = new List<GameObject>();
    private List<GameObject> inversePortalObjects = new List<GameObject>();

    private void FixedUpdate()
    {
        PasteObjectPositionInOtherPortal();
    }

    private void PasteObjectPositionInOtherPortal()
    {
        for (int i = 0; i < duplicatedObjects.Count; i++)
        {
            Vector3 objectFromPortal = transform.position - duplicatedObjects[i].transform.position;
            if (!duplicatedObjects[i].gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack)
            {
                // duplicatedObjects[i].GetComponent<ObjectInTheWay>().ShowSolid();
                enterPortalObjects[i].transform.position = enterPortal.position - new Vector3(objectFromPortal.x, objectFromPortal.y, objectFromPortal.z);
                enterPortalObjects[i].transform.rotation = duplicatedObjects[i].transform.rotation;
                enterPortalObjects[i].transform.localScale = duplicatedObjects[i].transform.localScale;
            }
            else
            {
                // duplicatedObjects[i].GetComponent<ObjectInTheWay>().ShowSolid();
                inversePortalObjects[i].transform.position = inversePortal.position - new Vector3(objectFromPortal.x, objectFromPortal.y, objectFromPortal.z);
                inversePortalObjects[i].transform.rotation = duplicatedObjects[i].transform.rotation;
                inversePortalObjects[i].transform.localScale = duplicatedObjects[i].transform.localScale;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!duplicatedObjects.Contains(other.gameObject))
            {
                if (!other.name.Contains("Clone"))
                {
                    GameObject instanceOfObject = Instantiate(other.gameObject, other.transform.position, Quaternion.identity) as GameObject;

                    if (!other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack)
                    {
                        instanceOfObject.transform.SetParent(enterPortal.parent);
                        enterPortalObjects.Add(instanceOfObject);
                    }
                    else
                    {
                        instanceOfObject.transform.SetParent(inversePortal.parent);
                        inversePortalObjects.Add(instanceOfObject);
                    }

                    Destroy(instanceOfObject.GetComponent<Gravity>());
                    Destroy(instanceOfObject.GetComponent<ObjectInTheWay>());
                    // Destroy(instanceOfObject.GetComponent<Collider>());
                    // Destroy(instanceOfObject.GetComponent<Rigidbody>());
                    duplicatedObjects.Add(other.gameObject);
                    other.gameObject.GetComponent<ObjectProperties>().isTeleporting = true;
                    instanceOfObject.GetComponent<ObjectProperties>().isTeleporting = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != Tags.PLAYER)
        {
            if (duplicatedObjects.Contains(other.gameObject))
            {
                int index = duplicatedObjects.IndexOf(other.gameObject);
                GameObject duplicated = enterPortalObjects[index];
                duplicatedObjects.RemoveAt(index);
                if (!other.gameObject.GetComponent<ObjectProperties>().hasEnteredFromBack)
                {
                    enterPortalObjects.RemoveAt(index);
                }
                else
                {
                    inversePortalObjects.RemoveAt(index);
                }
                Destroy(duplicated);
                other.gameObject.GetComponent<ObjectProperties>().isTeleporting = false;
            }
        }
    }


}
