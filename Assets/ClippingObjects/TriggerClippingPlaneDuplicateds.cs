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
            if (other.GetComponent<ObjectProperties>().isTeleporting)
            {
                if (other.transform.name.Contains(clipOnCube))
                {
                    clippingPlane.mat.color = other.GetComponent<Renderer>().material.color;
                    other.GetComponent<Renderer>().material = clippingPlane.mat;
                }

            }
        }
    }
}
