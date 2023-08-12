using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClippingObjects : MonoBehaviour
{
    [SerializeField]
    ClippingPlane clippingPlane;

    [SerializeField]
    bool neg = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (other.GetComponent<ObjectProperties>().isTeleporting && !other.name.Contains("Clone"))
            {
                if (!neg)
                {
                    if (other.GetComponent<ObjectProperties>().hasEnteredFromBack)
                    {
                        clippingPlane.mat.mainTexture = other.GetComponent<Renderer>().material.mainTexture;
                        other.GetComponent<Renderer>().material = clippingPlane.mat;
                    }
                }
                else
                {
                    if (!other.GetComponent<ObjectProperties>().hasEnteredFromBack)
                    {
                        clippingPlane.mat.mainTexture = other.GetComponent<Renderer>().material.mainTexture;
                        other.GetComponent<Renderer>().material = clippingPlane.mat;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (!other.name.Contains("Clone"))
            {
                other.GetComponent<Renderer>().material = other.GetComponent<ObjectProperties>().objectMat;

            }
        }
    }
}
