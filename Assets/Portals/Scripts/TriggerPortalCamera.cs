using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalCamera : MonoBehaviour
{
    [SerializeField]
    Transform cam;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == cam.name)
        {
            // Hide();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == cam.name)
        {
            // Show();
        }
    }

    // private void Show()
    // {
    //      cam.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer("ObjectMovable");
    // }

    // // Turn off the bit using an AND operation with the complement of the shifted int:
    // private void Hide()
    // {
    //      cam.GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("ObjectMovable"));
    // }
}
