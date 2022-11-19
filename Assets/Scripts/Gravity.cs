using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private GameObject gravityReferencePoint;
    public bool useGravity = false;
    private float verticalSpeed;

    [SerializeField]
    float gravity = 9.8f;
    private bool collisionWithCube;
    private Vector3 pointOnCollisionWithCube;

    private void Awake()
    {
        gravityReferencePoint = GameObject.Find("GravityReferencePoint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckCollision();
        UseGravity();
    }
    
    private void UseGravity()
    {
        if (useGravity)
        {
            verticalSpeed -= gravity * Time.fixedDeltaTime;
            transform.Translate((transform.up * verticalSpeed) * Time.fixedDeltaTime);
            transform.rotation = new Quaternion(0f,0f,0f,0f);
        }
    }
    private void CheckCollision(){
        if(collisionWithCube){
            verticalSpeed = -gravity * Time.fixedDeltaTime;
            transform.position = pointOnCollisionWithCube;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == Tags.CUBEWALL_TAG)
        {
            if (!collisionWithCube){
                collisionWithCube = true;
                pointOnCollisionWithCube = transform.position;
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.transform.tag == Tags.CUBEWALL_TAG)
        {
            if (collisionWithCube)
                collisionWithCube = false;
        }
    }
}
