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
            Debug.Log(other.name);
            if (other.GetComponent<ObjectIsTeleporting>().isTeleporting)
            {
                clippingPlane.mat.mainTexture = other.GetComponent<Renderer>().material.mainTexture;
                other.GetComponent<Renderer>().material = clippingPlane.mat;
            }
        }
    }
}