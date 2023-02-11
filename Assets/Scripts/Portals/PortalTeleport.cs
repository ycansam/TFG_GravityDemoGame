using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == Tags.PLAYER)
        {

            Transform player = other.transform;
            Vector3 playerFromPortal = transform.InverseTransformPoint(player.position);

        }
    }
}
