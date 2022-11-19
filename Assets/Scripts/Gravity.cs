using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private CubeController cubeController;

    // private GameObject gravityReferencePoint;
    public bool useGravity = false;

    [SerializeField]
    float gravity = 9.8f;

    // Elementos usado en el script
    private Rigidbody rb;
    private float verticalSpeed;
    private bool collisionWithWall;
    private bool collisionWithMovable;
    private Quaternion rotationOnCollision;
    private Vector3 positionOnCollision;

    private void Awake()
    {
        // gravityReferencePoint = GameObject.Find("GravityReferencePoint");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cubeController.IsRotating)
        {
            UseGravity();
            CheckCollisionWithWall();
        }
    }

    private void UseGravity()
    {
        if (useGravity)
        {
            if (!collisionWithWall)
                verticalSpeed -= gravity * Time.fixedDeltaTime;
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + (verticalSpeed * Time.fixedDeltaTime),
                transform.position.z
            );
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void CheckCollisionWithWall()
    {
        if (collisionWithWall)
        {
            verticalSpeed = 0;
            rb.velocity = Vector3.zero;
        }
        if (!cubeController.IsRotating && transform.rotation != rotationOnCollision)
        {
            collisionWithWall = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        OnCollisionEnterWithWall(other);
    }

    private void OnCollisionStay(Collision other)
    {
        OnCollisionEnterWithMovableObject(other);
    }

    private void OnCollisionEnterWithWall(Collision other)
    {
        if (other.transform.tag == Tags.CUBEWALL_TAG)
        {
            if (!collisionWithWall)
            {
                collisionWithWall = true;
                rotationOnCollision = transform.rotation;
                positionOnCollision = transform.position;
            }
        }
    }

    private void OnCollisionEnterWithMovableObject(Collision other)
    {
        if (other.transform.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (other.transform.position.y < transform.position.y)
            {
                verticalSpeed = 0;
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        OnCollisionExitWithWall(other);
    }

    private void OnCollisionExitWithWall(Collision other)
    {
        if (other.transform.tag == Tags.CUBEWALL_TAG)
        {
            if (collisionWithWall)
            {
                collisionWithWall = false;
            }
        }
    }
}
