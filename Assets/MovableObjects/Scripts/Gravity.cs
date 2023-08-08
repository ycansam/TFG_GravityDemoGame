using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private CubeRotator cubeRotator;

    public bool useGravity = false;

    [SerializeField]
    float gravity = 9.8f;

    [SerializeField]
    float mass = 1f;

    // Elementos usado en el script
    private Rigidbody rb;
    protected float verticalSpeed;
    private Transform player;
    private Vector3 actualDirection = Vector3.up;
    public LayerMask groundLayers;
    public int[] ingorePortalLayer;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        cubeRotator = FindObjectOfType<CubeRotator>();
    }
    void Update()
    {
        SetGravityDirection();
    }
    void FixedUpdate()
    {
        UseGravity();
        RigibodyStatsBasedOnRotation();
    }
    public void UseGravity(bool state)
    {
        useGravity = state;
    }
    // Actualiza el estado del RigidBody cuando rota el cubo
    private void RigibodyStatsBasedOnRotation()
    {
        if (cubeRotator != null && cubeRotator.IsRotating)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    // Actualiza la direccion basada en la pared en la que esta el jugador
    private void SetGravityDirection()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (CharacterWallsInformation.GetCharOnWallName() != null)
                if (PlayerOnWall.IsOnLeftWall())
                    actualDirection = Vector3.right;
                else if (PlayerOnWall.IsOnRightWall())
                    actualDirection = Vector3.left;
                else if (PlayerOnWall.IsOnFrontWall())
                    actualDirection = Vector3.back;
                else if (PlayerOnWall.IsOnBackWall())
                    actualDirection = Vector3.forward;
                else if (PlayerOnWall.IsOnTopWall())
                    actualDirection = Vector3.down;
                else if (PlayerOnWall.IsOnInferiorWall())
                    actualDirection = Vector3.up;
        }
    }

    // Update is called once per frame

    // Activa la gravedad
    private void UseGravity()
    {

        if (!IsGrounded() && useGravity)
        {
            rb.AddForce(GetGravityDirection() * gravity * mass, ForceMode.Acceleration);
        }
    }

    // Detecta si el cubo esta en el suelo o no
    private bool IsGrounded()
    {
        Vector3 origin = transform.position;
        origin.y += 0.1f;
        float distance = 1.2f;
        RaycastHit hit;

        if (IsOnAnyObject())
        {
            rb.velocity = Vector3.zero;
        }

        if (Physics.SphereCast(origin, 0.8f, GetGravityDirection(), out hit, distance, groundLayers))
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
            return true;
        }


        return false;
    }

    // Detecta si el cubo esta encima de otro cubo
    private bool IsOnAnyObject()
    {
        Debug.DrawRay(transform.position, GetGravityDirection() * 2.1f, Color.red);
        return Physics.Raycast(transform.position, GetGravityDirection() * 2.1f, 1f, LayerUtils.CreateLayerMask(true, ingorePortalLayer));
    }

    // Obtiene la direccion en la que debe ir la gravedad en funcion de la situacion del jugador
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
