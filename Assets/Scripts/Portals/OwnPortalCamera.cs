using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnPortalCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform otherCam;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion direction = Quaternion.Inverse(transform.rotation) * Camera.main.transform.rotation;
        otherCam.transform.localEulerAngles = new Vector3(
                                                        direction.eulerAngles.x,
                                                        direction.eulerAngles.y + 180,
                                                        direction.eulerAngles.z);
        Vector3 distance = transform.InverseTransformPoint(Camera.main.transform.position);
        otherCam.transform.localPosition = -new Vector3(distance.x, -distance.y, distance.z);

    }
}
