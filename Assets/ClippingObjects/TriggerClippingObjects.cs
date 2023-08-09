using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClippingObjects : MonoBehaviour
{
    ClippingPlane clippingPlane;

    private void Awake()
    {
        clippingPlane = GetComponent<ClippingPlane>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (other.GetComponent<ObjectIsTeleporting>().isTeleporting)
            {
                Debug.Log(other.name);
                other.GetComponent<Renderer>().material = clippingPlane.mat;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {

        }
    }
}
