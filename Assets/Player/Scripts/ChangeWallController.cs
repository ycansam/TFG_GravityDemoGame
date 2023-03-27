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

    private string playerOnWall;


    // Start is called before the first frame update
    void Start()
    {
        marker = Instantiate<GameObject>(markerPrefab);
        marker.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        LookingForwardRay();
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

    private void LookingForwardRay()
    {
        // Crea el rayo y lo debugea
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 50;
        Debug.DrawRay(playerHead.position, forward, Color.green);

        AssignMarkerPoint(Physics.RaycastAll(playerHead.position, forward, 4.0F));
        AssignHitHelpWall(Physics.RaycastAll(playerHead.position, forward, 50.0F));

    }

    // Asigna al marker un punto donde estar y aparecer
    private void AssignMarkerPoint(RaycastHit[] hits)
    {

        // Activa el marcador si tiene puntos detectados en el rayo
        ActiveMarker(hits.Length > 0);

        for (int i = 0; i < hits.Length; i++)
        {
            hit = hits[i];
            if (hit.transform.name.Contains("Wall") && !hit.transform.name.Contains("Help"))
                marker.transform.position = hit.point;
        }
    }

    // Asigna la pared de ayuda a la que esta mirando con el rayo
    private void AssignHitHelpWall(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            hit = hits[i];
            if (hit.transform.name.Contains("Wall") && hit.transform.name.Contains("Help"))
                hitHelpWall = hit;
        }
    }

    // Activa o desactiva el marcador dependiendo de la condicion
    private void ActiveMarker(bool activationCond)
    {
        if (!marker.activeSelf && activationCond)
            marker.SetActive(true);
        else if (marker.activeSelf && !activationCond)
            marker.SetActive(false);
    }

    public string GetPlayerOnWall()
    {
        return playerOnWall;
    }

}
