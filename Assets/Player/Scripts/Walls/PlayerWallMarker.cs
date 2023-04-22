using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallMarker : MonoBehaviour
{
    [SerializeField]
    private Transform playerHead;

    [SerializeField]
    private GameObject markerPrefab;

    private GameObject marker;
    private RaycastHit hit;
    private RaycastHit hitHelpWall;

    void Start()
    {
        marker = Instantiate<GameObject>(markerPrefab);
        marker.SetActive(false);
    }

    private void Update()
    {
        LookingForwardRay();
    }

    public bool IsMarkerActivated(){
        return marker.activeSelf;
    }
    
    private void LookingForwardRay()
    {
        // Crea el rayo y lo debugea
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 4F;
        Debug.DrawRay(playerHead.position, forward, Color.yellow);

        AssignMarkerPoint(Physics.RaycastAll(playerHead.position, forward, 4.0F));
    }

    // Asigna al marker un punto donde estar y aparecer
    private void AssignMarkerPoint(RaycastHit[] hits)
    {

        // Activa el marcador si tiene puntos detectados en el rayo
        ActiveMarker(hits.Length > 0);

        for (int i = 0; i < hits.Length; i++)
        {
            hit = hits[i];
            if (CharacterWallsInformation.IsRayHittingWall(hit))
                marker.transform.position = hit.point;
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

}
