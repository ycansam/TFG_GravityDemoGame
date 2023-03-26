using System.Collections.Generic;
using UnityEngine;
public class PlayerInCube : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private List<GameObject> colliderList = new List<GameObject>();

    private void OnTriggerEnter(Collider collider)
    {
        if (!colliderList.Contains(collider.gameObject))
        {
            colliderList.Add(collider.gameObject);
            Debug.Log("Added " + gameObject.name);
            Debug.Log("GameObjects in list: " + colliderList.Count);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (colliderList.Contains(collider.gameObject))
        {
            colliderList.Remove(collider.gameObject);
            Debug.Log("Removed " + gameObject.name);
            Debug.Log("GameObjects in list: " + colliderList.Count);
        }
    }

    public bool isPlayerOnCube()
    {
        return colliderList.Contains(player);
    }

}
