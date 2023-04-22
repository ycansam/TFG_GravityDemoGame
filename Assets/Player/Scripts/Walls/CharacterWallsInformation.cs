using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallsInformation : MonoBehaviour
{
    [SerializeField] private Transform playerHead;
    private static RaycastHit charOnHelpWallHit;
    private static RaycastHit charOnWallHit;
    private static RaycastHit charLookingAtHelpWallHit;
    private static RaycastHit charLookingAtWallHit;

    private static RaycastHit[] forwardHits;
    private static RaycastHit[] downwardHits;

    const string wallName = "Wall";
    const string helpName = "Help";

    public static string GetCharOnWallName()
    {
        return charOnWallHit.transform.name;
    }
    public static string GetCharOnWallHelpName()
    {
        return charOnHelpWallHit.transform.name;
    }
    public static string GetCharLookingAtWallName()
    {
        return charLookingAtWallHit.transform.name;
    }
    public static string GetCharLookingAtHelpWallName()
    {
        return charLookingAtHelpWallHit.transform.name;
    }
    public static RaycastHit[] GetDownwardHits()
    {
        return downwardHits;
    }
    void Update()
    {
        ForwardRay();
        DownwardRay();
    }

    private void ForwardRay()
    {
        // Crea el rayo y lo debugea
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 50;
        Debug.DrawRay(playerHead.position, forward, Color.green);
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
        forwardHits = Physics.RaycastAll(playerHead.position, forward, 50.0F);

        AssignCharLookingAtHelpWall(forwardHits);
        AssignCharLookingAtWall(Physics.RaycastAll(playerHead.position, forward, 50.0F));
    }

    private void AssignCharLookingAtHelpWall(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (IsRayHittingWallAndHelpWall(hit))
                charLookingAtHelpWallHit = hit;
        }
    }

    private void AssignCharLookingAtWall(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (IsRayHittingWall(hit))
                charLookingAtWallHit = hit;
        }
    }

    private void DownwardRay()
    {
        Vector3 downward = transform.TransformDirection(Vector3.down) * 50f;
        Debug.DrawRay(transform.position, downward, Color.green);
        downwardHits = Physics.RaycastAll(transform.position, downward, 50.0F);
        AssignPlayerOnHelpWall(Physics.RaycastAll(transform.position, downward, 50.0F));
        AssignPlayerOnWall(Physics.RaycastAll(transform.position, downward, 50.0F));
    }

    private void AssignPlayerOnHelpWall(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (IsRayHittingWallAndHelpWall(hit))
                charOnHelpWallHit = hit;
        }
    }


    private void AssignPlayerOnWall(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (IsRayHittingWall(hit))
                charOnWallHit = hit;
        }
    }
    public static bool IsRayHittingWallAndHelpWall(RaycastHit hit)
    {
        return hit.transform.name.Contains(wallName) && hit.transform.name.Contains(helpName);
    }

    public static bool IsRayHittingWall(RaycastHit hit)
    {
        return hit.transform.name.Contains(wallName) && !hit.transform.name.Contains(helpName);
    }


}
