using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private bool isRotating = false;
    public bool IsRotating
    {
        get { return this.isRotating; }
        private set { this.isRotating = value; }
    }

    [SerializeField]
    private float rotationSpeed = 1f;

    void Start() { }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(RotateRight());
        }
    }

    IEnumerator RotateRight()
    {
        float y = 180;
        while (transform.rotation.y < 180)
        {
            transform.localRotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.AngleAxis(90f, Vector3.right),
                rotationSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        yield return null;
    }
}
