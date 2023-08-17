using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovableObjectsInCube : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> colliderList = new List<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!other.gameObject.name.Contains("Clone"))
                if (!colliderList.Contains(other.gameObject))
                {
                    colliderList.Add(other.gameObject);
                    other.gameObject.transform.parent = transform;
                }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (colliderList.Contains(other.gameObject))
            {
                other.gameObject.transform.parent = null;
                colliderList.Remove(other.gameObject);
            }
        }
    }
}
