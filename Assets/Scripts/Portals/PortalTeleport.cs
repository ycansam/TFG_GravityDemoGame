using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;
    [SerializeField]
    private bool neg;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == Tags.PLAYER)
        {

            Vector3 playerFromPortal = transform.position - player.position;
            Debug.Log(playerFromPortal.x);
            if (!neg)
            {
                if (playerFromPortal.x <= -0.02)
                    player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
            else
            {
                if (playerFromPortal.x >= -0.02)
                    player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }

        }
    }

}
