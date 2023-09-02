using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalCamera : MonoBehaviour
{
    static private string playerTriggeredByTransform;
    [SerializeField]
    private Transform player;

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

            teleportingObjetcsClass.Add(teleportItem);
            teleportingObjetcs.Add(ob);
        }
    }

    private void PushTeleportingClone(GameObject ob)
    {

        if (!teleportingClones.Contains(ob))
        {
            TeleportItems teleportItem = new TeleportItems();
            teleportItem.item = ob;
            teleportItem.triggeredTransform = transform.name;

            teleportingClonesClass.Add(teleportItem);
            teleportingClones.Add(ob);
        }
    }

    private void RemoveMovableIfIncluded(GameObject ob)
    {
        if (includedObjects.Contains(ob))
        {
            int index = includedObjects.IndexOf(ob);
            if (index != -1)
                includedObjects.RemoveAt(index);
        }
        if (teleportingClones.Contains(ob))
        {
            int index = teleportingClones.IndexOf(ob);
            if (index != -1)
            {
                teleportingClonesClass.RemoveAt(index);
                teleportingClones.RemoveAt(index);
            }
        }
        if (teleportingObjetcs.Contains(ob))
        {
            int index = teleportingObjetcs.IndexOf(ob);
            if (index != -1)
            {
                teleportingObjetcsClass.RemoveAt(index);
                teleportingObjetcs.RemoveAt(index);
            }
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

        for (int i = 0; i < teleportingClonesClass.Count; i++)
        {
            if (playerTriggeredByTransform != teleportingClonesClass[i].triggeredTransform)
            {
                if (i < teleportingObjetcsClass.Count)
                    if (!teleportingObjetcsClass[i].triggeredTransform.Contains("("))
                    {
                        if (transform.name.Contains("("))
                        {
                            if (teleportingClones[i] != null)
                            {
                                teleportingClones[i].GetComponent<MeshRenderer>().enabled = false;
                            }
                        }
                    }
                    else if (teleportingObjetcsClass[i].triggeredTransform.Contains("("))
                    {
                        if (!transform.name.Contains("("))
                        {
                            if (teleportingClones[i] != null)
                                teleportingClones[i].GetComponent<MeshRenderer>().enabled = false;
                        }
                    }
            }

        }
    }

    private void EnableObjectRenders()
    {
        foreach (GameObject ob in includedObjects)
        {
            if (ob != null)
                ob.GetComponent<MeshRenderer>().enabled = true;
        }
        foreach (GameObject ob in teleportingClones)
        {
            if (ob != null)
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
                        if (!teleportingObjetcsClass[teleportingObjetcs.Count - 1].triggeredTransform.Contains("("))
                        {
                            if (transform.name.Contains("("))
                            {
                                PushTeleportingClone(other.gameObject);
                            }
                        }
                        else
                        {
                            if (!transform.name.Contains("("))
                            {
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
            EnableObjectRenders();
            playerTriggeredByTransform = transform.name;

            for (int i = 0; i < teleportingObjetcsClass.Count; i++)
            {
                if (teleportingObjetcsClass[i].item != null)
                {
                    if (teleportingObjetcsClass[i].triggeredTransform != playerTriggeredByTransform)
                    {
                        if (i < teleportingClonesClass.Count)
                        {
                            if (teleportingClonesClass[i].item != null)
                            {
                                if (teleportingClonesClass[i].triggeredTransform != playerTriggeredByTransform)
                                {
                                    teleportingClonesClass[i].item.GetComponent<MeshRenderer>().enabled = false;
                                    if (teleportingObjetcsClass[i] != null)
                                    {
                                        Physics.IgnoreCollision(player.GetComponent<Collider>(), teleportingObjetcsClass[i].item.GetComponent<Collider>());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Physics.IgnoreCollision(player.GetComponent<Collider>(), teleportingObjetcsClass[i].item.GetComponent<Collider>(), false);
                    }
                }
            }

            for (int i = 0; i < teleportingClonesClass.Count; i++)
            {
                if (teleportingClonesClass[i].item != null)
                {
                    if (teleportingClonesClass[i].triggeredTransform != playerTriggeredByTransform)
                    {
                        if (i < teleportingObjetcsClass.Count)
                        {
                            if (teleportingObjetcsClass[i].item != null)
                            {
                                if (teleportingObjetcsClass[i].triggeredTransform != playerTriggeredByTransform)
                                {
                                    Physics.IgnoreCollision(player.GetComponent<Collider>(), teleportingClonesClass[i].item.GetComponent<Collider>());
                                }
                            }
                        }
                    }
                    else
                    {
                        Physics.IgnoreCollision(player.GetComponent<Collider>(), teleportingClonesClass[i].item.GetComponent<Collider>(), false);
                    }
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            EnableObjectRenders();
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
