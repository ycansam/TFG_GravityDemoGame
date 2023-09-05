using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMoverStart : MonoBehaviour
{
    [SerializeField]
    Transform staticMovable;

 
    private void Update()
    {
        Vector3 newPosition = Vector3.Lerp(staticMovable.position, transform.position, 2 * Time.deltaTime);

        // Move the object to the new position
        staticMovable.position = newPosition;
    }
}
