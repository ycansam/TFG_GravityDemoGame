using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableObjects : MonoBehaviour
{

    private void OnCollisionStay(Collision other)
    {
        if (transform.parent.name.Contains("CatchableObject"))
        {
            Transform pointMovableObject = transform.parent;
            CatchStaticObjetcs.collided = true;
            transform.position = Vector3.Lerp(transform.position, pointMovableObject.transform.position, 0.2f * Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        CatchStaticObjetcs.collided = false;
    }
}

