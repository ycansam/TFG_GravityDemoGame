using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallController : MonoBehaviour
{
    [SerializeField]
    private Transform playerHead;

    [SerializeField]
    private GameObject markerPrefab;
    private GameObject marker;
    private RaycastHit hit;
    private RaycastHit hitHelpWall;

    public static string playerOnWall;


    // Start is called before the first frame update
    void Start()
    {
        marker = Instantiate<GameObject>(markerPrefab);
        marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LookingWall();
        Controls();
    }

    private void Controls()
    {
        if (Input.GetKeyDown(KeyCode.X) && marker.activeSelf)
        {
            transform.eulerAngles = hit.transform.eulerAngles;
            playerOnWall = hitHelpWall.transform.name;
        }
    }

    private void LookingWall()
    {
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 50;

        Debug.DrawRay(playerHead.position, forward, Color.green);

        RaycastHit[] hits;
        RaycastHit[] hits2;
        hits = Physics.RaycastAll(playerHead.position, forward, 2.0F);
        hits2 = Physics.RaycastAll(playerHead.position, forward, 50.0F);

        if (hits.Length > 0)
        {
            ActiveMarker();
            for (int i = 0; i < hits.Length; i++)
            {
                hit = hits[i];
                if (hit.transform.name.Contains("Wall") && !hit.transform.name.Contains("Help"))
                    marker.transform.position = hit.point;
            }
        }
        else if (hits.Length == 0)
        {
            DesactiveMarker();
        }

        for (int i = 0; i < hits2.Length; i++)
        {
            hit = hits2[i];
            if (hit.transform.name.Contains("Wall") && hit.transform.name.Contains("Help"))
                hitHelpWall = hit;
        }

    }

    private void ActiveMarker()
    {
        if (!marker.activeSelf)
            marker.SetActive(true);
    }
    private void DesactiveMarker()
    {
        if (marker.activeSelf)
            marker.SetActive(false);
    }


}
