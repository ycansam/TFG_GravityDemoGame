using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectDuplicator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;

    private List<GameObject> duplicatedObjects = new List<GameObject>();
    private List<GameObject> otherPortalObjects = new List<GameObject>();

    private void FixedUpdate()
    {
        PasteObjectPositionInOtherPortal();
    }

    private void PasteObjectPositionInOtherPortal()
    {
        for (int i = 0; i < duplicatedObjects.Count; i++)
        {
            Vector3 objectFromPortal = transform.position - duplicatedObjects[i].transform.position;
            // duplicatedObjects[i].GetComponent<ObjectInTheWay>().ShowSolid();
            otherPortalObjects[i].transform.position = otherPortal.position - new Vector3(objectFromPortal.x, objectFromPortal.y, objectFromPortal.z);
            otherPortalObjects[i].transform.rotation = duplicatedObjects[i].transform.rotation;
            otherPortalObjects[i].transform.localScale = duplicatedObjects[i].transform.localScale;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != Tags.PLAYER)
        {
            if (!duplicatedObjects.Contains(other.gameObject))
            {
                if (!other.name.Contains("Clone"))
                {
                    GameObject instanceOfObject = Instantiate(other.gameObject, other.transform.position, Quaternion.identity) as GameObject;
                    instanceOfObject.transform.SetParent(otherPortal.parent);
                    // Destroy(instanceOfObject.GetComponent<Collider>());
                    Destroy(instanceOfObject.GetComponent<Gravity>());
                    // Destroy(instanceOfObject.GetComponent<Rigidbody>());
                    Destroy(instanceOfObject.GetComponent<ObjectInTheWay>());
                    duplicatedObjects.Add(other.gameObject);
                    otherPortalObjects.Add(instanceOfObject);
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
                GameObject duplicated = otherPortalObjects[index];
                duplicatedObjects.RemoveAt(index);
                otherPortalObjects.RemoveAt(index);
                Destroy(duplicated);
                other.gameObject.GetComponent<ObjectProperties>().isTeleporting = false;
            }
        }
    }


}
