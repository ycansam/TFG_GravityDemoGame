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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!duplicatedEnterObjects.Contains(other.gameObject))
            {
                if (!other.name.Contains("Clone") && !ObjectHasEnteredFromBack(other.gameObject))
                {
                    duplicatedEnterObjects.Add(other.gameObject);
                }
            }

            if (!duplicatedInverseObjects.Contains(other.gameObject))
                if (!other.name.Contains("Clone") && ObjectHasEnteredFromBack(other.gameObject))
                {
                    duplicatedInverseObjects.Add(other.gameObject);
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