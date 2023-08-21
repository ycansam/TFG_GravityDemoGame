using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherPortal;

    [SerializeField]
    private Transform exitPortal;

    [SerializeField]
    private Transform enterPoint;

    [SerializeField]
    private Transform exitPoint;

    private Transform player;
    private PlayerStats playerStats;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        playerStats = player.GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            playerStats.hasEnteredFromBack = PlayerHasEnteredFromInverse();
            playerStats.enteredPortal = transform.name;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == Tags.PLAYER)
        {
            Vector3 playerFromPortal = transform.position - player.position;
            float playerFromPortalDistance = GetPlayerFromPortalDistance();
            if (transform.name == playerStats.enteredPortal)
            {
                if (!playerStats.hasEnteredFromBack)
                {
                    if (playerFromPortalDistance < 0)
                    {
                        player.transform.position = otherPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                    }
                }
                else
                {
                    if (playerFromPortalDistance > 0)
                    {
                        player.transform.position = exitPortal.position - new Vector3(playerFromPortal.x, playerFromPortal.y, playerFromPortal.z);
                    }
                }
            }
        }
    }

    private float GetPlayerFromPortalDistance()
    {

        Vector3 objectFromEntryPoint = enterPoint.position - player.transform.position;
        Vector3 objectFromExitPoint = exitPoint.position - player.transform.position;
        float distance = objectFromEntryPoint.magnitude - objectFromExitPoint.magnitude;
        return -distance;
    }

    private bool PlayerHasEnteredFromInverse()
    {
        Vector3 objectFromEntryPoint = enterPoint.position - player.transform.position;
        Vector3 objectFromExitPoint = exitPoint.position - player.transform.position;
        float direction = objectFromEntryPoint.magnitude - objectFromExitPoint.magnitude;
        if (direction > 0)
            return true;
        return false;
    }
}
