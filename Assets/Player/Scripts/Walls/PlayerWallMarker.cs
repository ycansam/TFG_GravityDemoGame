using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallMarker : MonoBehaviour
{
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
        playerHead = GameObject.FindGameObjectWithTag(Tags.PLAYER_HEAD).transform;
    }

    private void Update()
    {
        if (PlayerSuit.HasSuit()) LookingForwardRay();
    }

    public bool IsMarkerActivated()
    {
        return marker.activeSelf;
    }

    private void LookingForwardRay()
    {
        // Crea el rayo y lo debugea
        Vector3 forward = playerHead.TransformDirection(Vector3.forward) * 4F;
        Debug.DrawRay(playerHead.position, forward, Color.yellow);

        AssignMarkerPoint(Physics.RaycastAll(playerHead.position, forward, 4.0F, 9));
    }

    // Asigna al marker un punto donde estar y aparecer
    private void AssignMarkerPoint(RaycastHit[] hits)
    {

        for (int i = 0; i < hits.Length; i++)
        {
            hit = hits[i];
            if (hit.transform.tag != Tags.PLAYER)
            {
                Debug.Log(hit.transform.name);
                if (CharacterWallsInformation.IsRayHittingInvalidWall(hit))
                    return;
                if (CharacterWallsInformation.IsRayHittingWall(hit))
                    marker.transform.position = hit.point;
            }else{
            }

        }

        // Activa el marcador si tiene puntos detectados en el rayo
        Debug.Log(hits.Length);
        ActiveMarker(hits.Length > 0);
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
