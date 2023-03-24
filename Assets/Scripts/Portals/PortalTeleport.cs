using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;

    // Booleano que inidica si esta en un lado u otro
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

            float distance = 0.02f;
            Vector3 playerFromPortal = transform.position - player.position;
            // si es negativo 
            Debug.Log(playerFromPortal);
            if (!neg)
            {
                if (playerFromPortal.x <= -distance )
                    player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
            else
            {
                //  || playerFromPortal.y >= -distance || playerFromPortal.z >= -distance
                if (playerFromPortal.x >= -distance)
                    player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
            }
        }
    }

}
