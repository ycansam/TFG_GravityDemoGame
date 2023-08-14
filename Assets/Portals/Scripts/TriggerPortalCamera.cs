using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalCamera : MonoBehaviour
{
    static private string playerTriggeredByTransform;

    private class TeleportItems
    {
        public GameObject item;
        public string triggeredTransform;
    }

    [SerializeField]
    private List<Transform> portalCameras = new List<Transform>();
    private List<GameObject> includedObjects = new List<GameObject>();
    static private List<GameObject> teleportingClones = new List<GameObject>();
    static private List<TeleportItems> teleportingClonesClass = new List<TeleportItems>();
    static private List<GameObject> teleportingObjetcs = new List<GameObject>();
    static private List<TeleportItems> teleportingObjetcsClass = new List<TeleportItems>();


    private void IncludeMovableIfNotIncluded(GameObject ob)
    {
        if (!includedObjects.Contains(ob))
        {
            includedObjects.Add(ob);
        }
    }
    private void PushTeleportingObject(GameObject ob)
    {
        if (!teleportingObjetcs.Contains(ob))
        {
            TeleportItems teleportItem = new TeleportItems();
            teleportItem.item = ob;
            teleportItem.triggeredTransform = transform.name;
            teleportingObjetcs.Add(ob);
            teleportingObjetcsClass.Add(teleportItem);
        }
    }

    private void PushTeleportingClone(GameObject ob)
    {

        if (!teleportingClones.Contains(ob))
        {
            TeleportItems teleportItem = new TeleportItems();
            teleportItem.item = ob;
            teleportItem.triggeredTransform = transform.name;

            teleportingClones.Add(ob);
            teleportingClonesClass.Add(teleportItem);
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

    private void DisableObjectCloneRenders()
    {

        Debug.Log("PLAYER: " + playerTriggeredByTransform);
        for (int i = 0; i < teleportingClonesClass.Count; i++)
        {
            // if (!teleportingObjetcsClass[i].triggeredTransform.Contains("("))
            // {
                //  ME HE QUEDADO POR AQUI
            if (transform.name.Contains("("))
            {
                Debug.Log(transform.name);
                Debug.Log(teleportingClonesClass[i].triggeredTransform);
                if (playerTriggeredByTransform != teleportingClonesClass[i].triggeredTransform)
                {
                    teleportingClones[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
         
        }
    }

    private void EnableObjectRenders()
    {
        foreach (GameObject ob in includedObjects)
        {
            ob.GetComponent<MeshRenderer>().enabled = true;
        }
        foreach (GameObject ob in teleportingClones)
        {
            ob.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!other.GetComponent<ObjectProperties>().isTeleporting)
            {
                IncludeMovableIfNotIncluded(other.gameObject);
            }
            else
            {
                if (!other.name.Contains("Clone"))
                {
                    PushTeleportingObject(other.gameObject);
                }
                else
                {
                    if (teleportingObjetcs.Count > 0)
                    {
                        // Debug.Log(teleportingObjetcsClass[teleportingObjetcs.Count - 1].triggeredTransform);
                        if (!teleportingObjetcsClass[teleportingObjetcs.Count - 1].triggeredTransform.Contains("("))
                        {
                            if (transform.name.Contains("("))
                            {
                                // Debug.Log(transform.name);
                                PushTeleportingClone(other.gameObject);
                            }
                        }
                    }
                }
            }
        }

        foreach (Transform portalCamera in portalCameras)
        {
            if (other.name == portalCamera.name)
            {
                DisableObjectRenders();
                DisableObjectCloneRenders();
            }
        }
        if (other.tag == Tags.PLAYER)
        {
            playerTriggeredByTransform = transform.name;
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
