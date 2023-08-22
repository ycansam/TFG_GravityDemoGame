using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersDisabler : MonoBehaviour
{

    [SerializeField]
    private Transform enterPoint;
    [SerializeField]
    private Transform exitPoint;

    private List<GameObject> duplicatedEnterObjects = new List<GameObject>();
    private List<GameObject> duplicatedInverseObjects = new List<GameObject>();

    private List<GameObject> duplicatedEnterCloneObjects = new List<GameObject>();
    private List<GameObject> duplicatedInverseCloneObjects = new List<GameObject>();

    private void DisableCollidersFromEachOtherClones(GameObject ob)
    {
        if (duplicatedEnterCloneObjects.Contains(ob))
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
        if (duplicatedInverseCloneObjects.Contains(ob))
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!other.name.Contains("Clone"))
            {
                if (!duplicatedEnterObjects.Contains(other.gameObject))
                {
                    if (!ObjectHasEnteredFromBack(other.gameObject))
                    {
                        duplicatedEnterObjects.Add(other.gameObject);
                    }
                }

                if (!duplicatedInverseObjects.Contains(other.gameObject))
                    if (ObjectHasEnteredFromBack(other.gameObject))
                    {
                        duplicatedInverseObjects.Add(other.gameObject);
                    }
                DisableCollidersFromEachOther(other.gameObject);
            }

            if (other.name.Contains("Clone"))
            {
                if (!duplicatedEnterCloneObjects.Contains(other.gameObject))
                {
                    if (!ObjectHasEnteredFromBack(other.gameObject))
                    {
                        duplicatedEnterCloneObjects.Add(other.gameObject);
                    }
                }

                if (!duplicatedInverseCloneObjects.Contains(other.gameObject))
                {
                    if (ObjectHasEnteredFromBack(other.gameObject))
                    {
                        duplicatedInverseCloneObjects.Add(other.gameObject);
                    }
                }
                DisableCollidersFromEachOtherClones(other.gameObject);
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
                }
            }
            if (duplicatedInverseObjects.Contains(other.gameObject))
            {
                int index = duplicatedInverseObjects.IndexOf(other.gameObject);
                if (index != -1)
                {
                    duplicatedInverseObjects.RemoveAt(index);
                }
            }
            if (duplicatedEnterCloneObjects.Contains(other.gameObject))
            {
                int index = duplicatedEnterCloneObjects.IndexOf(other.gameObject);
                if (index != -1)
                {
                    duplicatedEnterCloneObjects.RemoveAt(index);
                }
            }
            if (duplicatedInverseCloneObjects.Contains(other.gameObject))
            {
                int index = duplicatedInverseCloneObjects.IndexOf(other.gameObject);
                if (index != -1)
                {
                    duplicatedInverseCloneObjects.RemoveAt(index);
                }
            }
        }
    }

    private bool ObjectHasEnteredFromBack(GameObject objectToTp)
    {
        Vector3 objectFromEntryPoint = enterPoint.position - objectToTp.transform.position;
        Vector3 objectFromExitPoint = exitPoint.position - objectToTp.transform.position;
        float direction = objectFromEntryPoint.magnitude - objectFromExitPoint.magnitude;
        if (direction > 0)
            return true;
        return false;
    }

}