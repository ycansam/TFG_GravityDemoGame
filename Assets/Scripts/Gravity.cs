using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private CubeController cubeController;

    private GameObject gravityReferencePoint;
    private Rigidbody rb;
    public bool useGravity = false;
    public float verticalSpeed;

    [SerializeField]
    float gravity = 9.8f;
    private bool collisionWithCube;
    private Quaternion rotationOnCollision;
    private Vector3 positionOnCollision;

    private void Awake()
    {
        gravityReferencePoint = GameObject.Find("GravityReferencePoint");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cubeController.IsRotating)
        {
            UseGravity();
            CheckCollision();
        }
    }

    private void UseGravity()
    {
        if (useGravity)
        {
            if (!collisionWithCube)
                verticalSpeed -= gravity * Time.fixedDeltaTime;
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + (verticalSpeed * Time.fixedDeltaTime),
                transform.position.z
            );
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void CheckCollision()
    {
        if (collisionWithCube)
        {
            verticalSpeed = 0;
            rb.velocity = Vector3.zero;
        }
        if (!cubeController.IsRotating && transform.rotation != rotationOnCollision)
        {
            collisionWithCube = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == Tags.CUBEWALL_TAG)
        {
            if (!collisionWithCube)
            {
                collisionWithCube = true;
                rotationOnCollision = transform.rotation;
                positionOnCollision = transform.position;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == Tags.CUBEWALL_TAG)
        {
            if (collisionWithCube)
            {
                collisionWithCube = false;
            }
        }
    }
}
