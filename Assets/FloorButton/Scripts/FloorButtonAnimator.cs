using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonAnimator : MonoBehaviour
{

    [SerializeField]
    private Transform activatedPoint;

    [SerializeField]
    private Transform desactivatedPoint;
    [SerializeField]
    private Transform flootButton;

    private bool activated;

    public void Activate()
    {
        activated = true;
    }
    public void Desactivate()
    {
        activated = false;
    }
    private void Update()
    {
        if (activated)
        {
            // Calculate the new position
            Vector3 newPosition = Vector3.Lerp(flootButton.position, activatedPoint.position, 2 * Time.deltaTime);

            // Move the object to the new position
            flootButton.position = newPosition;
        }
        else
        {
            // Calculate the new position
            Vector3 newPosition = Vector3.Lerp(flootButton.position, desactivatedPoint.position, 2 * Time.deltaTime);

            // Move the object to the new position
            flootButton.position = newPosition;
        }
    }
}
