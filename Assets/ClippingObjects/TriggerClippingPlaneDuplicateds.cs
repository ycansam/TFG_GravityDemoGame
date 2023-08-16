using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClippingPlaneDuplicateds : MonoBehaviour
{
    ClippingPlaneDuplicateds clippingPlane;

    private void Awake()
    {
        clippingPlane = GetComponent<ClippingPlaneDuplicateds>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG && other.name.Contains("Clone"))
        {

            // if (transform.parent.name.Contains("Rotator"))
            // {
            // if (other.transform.parent.name != transform.parent.name)
            if (other.GetComponent<ObjectProperties>().isTeleporting)
            {
                clippingPlane.mat.mainTexture = other.GetComponent<Renderer>().material.mainTexture;
                other.GetComponent<Renderer>().material = clippingPlane.mat;
            }
            Debug.Log(transform.parent.name);
            Debug.Log(other.transform.parent.name);
            // }

        }
    }
}
