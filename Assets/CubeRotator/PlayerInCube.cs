using System.Collections.Generic;
using UnityEngine;
public class PlayerInCube : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Camera camToPhone;

    private List<GameObject> colliderList = new List<GameObject>();

    private void Update()
    {
        if (camToPhone != null)
            if (isPlayerOnCube())
            {
                camToPhone.depth = 1;
            }
            else
            {
                camToPhone.depth = 0;
            }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!colliderList.Contains(collider.gameObject))
        {
            colliderList.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (colliderList.Contains(collider.gameObject))
        {
            colliderList.Remove(collider.gameObject);
        }
    }

    public bool isPlayerOnCube()
    {
        return colliderList.Contains(player);
    }

}
