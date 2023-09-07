using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMoverStart : MonoBehaviour
{
    [SerializeField]
    Transform staticMovable;
    public float useDelay = 0f;
    private float elapsedTime = 0f;
    private void Update()
    {
        if (elapsedTime >= useDelay)
        {
            Vector3 newPosition = Vector3.Lerp(staticMovable.position, transform.position, 2.2f * Time.deltaTime);

            // Move the object to the new position
            staticMovable.position = newPosition;
        }
        elapsedTime += Time.deltaTime;
    }
}
