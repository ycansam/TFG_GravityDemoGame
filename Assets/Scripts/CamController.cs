using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;
      [SerializeField]
    private GameObject astra3d;
    float mouseSensitivity = 500;

    private float xRotation = 0f;
    private float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        astra3d.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


        // astra3d.transform.Rotate(Vector3.right * -mouseY);
    }
}
