using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private CubeController cubeController;

    public bool useGravity = false;

    [SerializeField]
    float gravity = 9.8f;

    [SerializeField]
    float mass = 1f;

    // Elementos usado en el script
    public Rigidbody rb;
    protected float verticalSpeed;
    private Transform player;
    private Vector3 actualDirection = Vector3.up;
    public LayerMask groundLayers;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (ChangeWallController.playerOnWall != null)
                if (ChangeWallController.playerOnWall.Contains("Left"))
                    actualDirection = Vector3.right;
                else if (ChangeWallController.playerOnWall.Contains("Right"))
                    actualDirection = Vector3.left;
                else if (ChangeWallController.playerOnWall.Contains("Front"))
                    actualDirection = Vector3.back;
                else if (ChangeWallController.playerOnWall.Contains("Back"))
                    actualDirection = Vector3.forward;
                else if (ChangeWallController.playerOnWall.Contains("Top"))
                    actualDirection = Vector3.down;
                else if (ChangeWallController.playerOnWall.Contains("Inferior"))
                    actualDirection = Vector3.up;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UseGravity();
        if (cubeController.IsRotating)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void UseGravity()
    {

        if (!IsGrounded() && useGravity)
        {
            rb.AddForce(GetGravityDirection() * gravity * mass, ForceMode.Acceleration);
        }
    }

    private bool IsGrounded()
    {
        Vector3 origin = transform.position;
        origin.y += 0.1f;
        float distance = 2.5f;
        RaycastHit hit;

        if (IsOnAnyObject())
        {
            rb.velocity = Vector3.zero;
        }

        if (Physics.SphereCast(origin, 3f, GetGravityDirection(), out hit, distance, groundLayers))
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
            return true;
        }


        return false;
    }

    private bool IsOnAnyObject()
    {
        Debug.DrawRay(transform.position, GetGravityDirection() * 2.1f, Color.red);
        return Physics.Raycast(transform.position, GetGravityDirection() * 2.1f, 2.1f);
    }

    private Vector3 GetGravityDirection()
    {

        if (actualDirection == Vector3.up)
            return Vector3.down;
        else if (actualDirection == Vector3.right)
            return Vector3.left;
        else if (actualDirection == Vector3.left)
            return Vector3.right;
        else if (actualDirection == Vector3.down)
            return Vector3.up;
        else if (actualDirection == Vector3.forward)
            return Vector3.back;
        else
            return Vector3.forward;
    }

}
