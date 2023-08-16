using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClippingPlaneDuplicateds : MonoBehaviour
{
    ClippingPlaneDuplicateds clippingPlane;
    [SerializeField]
    private string clipOnCube = "-1";

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
                if (other.transform.name.Contains(clipOnCube))
                {
                    clippingPlane.mat.mainTexture = other.GetComponent<Renderer>().material.mainTexture;
                    other.GetComponent<Renderer>().material = clippingPlane.mat;
                }

            }
            Debug.Log(other.transform.name);
            // }

        }
    }
}
