using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchStaticObjetcs : MonoBehaviour
{
    private Rigidbody rb;
    public static bool collided = false;
    private float distance;
   
    // Update is called once per frame
    public void UpdatePos(Transform pointMovableObject, Transform objectCatched)
    {
        objectCatched.rotation = transform.rotation;
        distance = Vector3.Distance(objectCatched.position, pointMovableObject.transform.position);
        if (!collided)
        {
            objectCatched.position = Vector3.Lerp(objectCatched.position, pointMovableObject.transform.position, 5f * Time.deltaTime);
            rb.Sleep();
        }
    }

    public void ControlObject(Transform pointMovableObject, Transform objectCatched)
    {
        rb = objectCatched.GetComponent<Rigidbody>();
        objectCatched.SetParent(pointMovableObject.gameObject.transform);
        objectCatched.transform.rotation = Quaternion.Euler(new Vector3(0, gameObject.transform.rotation.y, 0));
        rb.isKinematic = false;
    }

    public void stopControlingObject(Transform collectedObject)
    {
        collectedObject.gameObject.transform.SetParent(null);
        rb.isKinematic = true;
    }
}

