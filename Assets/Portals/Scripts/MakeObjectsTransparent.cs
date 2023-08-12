using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectsTransparent : MonoBehaviour
{
    [SerializeField] private List<ObjectInTheWay> currentlyInTheWay;
    [SerializeField] private List<ObjectInTheWay> alreadyTransparent;

    [SerializeField] private List<Transform> contactPoints;
    private Transform cam;


    void Awake()
    {
        currentlyInTheWay = new List<ObjectInTheWay>();
        alreadyTransparent = new List<ObjectInTheWay>();
        cam = this.gameObject.transform;

    }

    void Update()
    {
        // GetAllObjectsInTheWay();

        // TurnObjectsSolid();
        // TurnObjectsTransparent();
    }

    private void GetAllObjectsInTheWay()
    {
        currentlyInTheWay.Clear();

        foreach (Transform wall in contactPoints)
        {
            float cameraPlayerDistance = Vector3.Magnitude(cam.position - wall.position);
            if (cameraPlayerDistance < 50f)
            {
                Ray ray1_Forward = new Ray(cam.position, wall.position - cam.position);
                Ray ray1_Backward = new Ray(wall.position, cam.position - wall.position);

                Debug.DrawRay(cam.position, ray1_Forward.direction * cameraPlayerDistance, Color.green);


                var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
                var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

                foreach (var hit in hits1_Forward)
                {

                    if (hit.collider.gameObject.TryGetComponent(out ObjectInTheWay inTheWay))
                    {
                        if (!currentlyInTheWay.Contains(inTheWay))
                        {
                            currentlyInTheWay.Add(inTheWay);
                        }
                    }
                }

                foreach (var hit in hits1_Backward)
                {
                    if (hit.collider.gameObject.TryGetComponent(out ObjectInTheWay inTheWay))
                    {
                        if (!currentlyInTheWay.Contains(inTheWay))
                        {
                            currentlyInTheWay.Add(inTheWay);
                        }
                    }
                }
            }
        }




    }

    private void TurnObjectsTransparent()
    {
        for (int i = 0; i < currentlyInTheWay.Count; i++)
        {
            ObjectInTheWay inTheWay = currentlyInTheWay[i];

            if (!alreadyTransparent.Contains(inTheWay))
            {
                inTheWay.ShowTransparent();
                alreadyTransparent.Add(inTheWay);
            }
        }
    }

    private void TurnObjectsSolid()
    {
        for (int i = alreadyTransparent.Count - 1; i >= 0; i--)
        {
            ObjectInTheWay wasInTheWay = alreadyTransparent[i];

            if (!currentlyInTheWay.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                alreadyTransparent.Remove(wasInTheWay);
            }
        }
    }




}
