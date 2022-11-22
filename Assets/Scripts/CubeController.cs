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

    private float rotateAngleHorizontal = 90f;

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
        while (transform.rotation.y < rotateAngleHorizontal)
        {
            transform.localRotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.AngleAxis(rotateAngleHorizontal, Vector3.forward),
                rotationSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(0, rotateAngleHorizontal, 0);
        rotateAngleHorizontal = rotateAngleHorizontal + 90f;
        yield return null;
    }
}
