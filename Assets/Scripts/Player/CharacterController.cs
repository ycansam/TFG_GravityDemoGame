using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CubeController))]
public class CharacterController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private CubeController cubeController;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Transform cubeFather;

    [Header("Move Settings")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool gravityEnabled;

    [Header("Variables")]
    private float vertical_axis;
    private float horizontal_axis;
    private float gravity;
    private float verticalSpeed;

    void Start()
    {
        gravity = GameConstants.PLAYERS_GRAVITY;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gravityEnabled && !cubeController.IsRotating)
            PlayerGravity();
        GetInput();
        PlayerMove();
        // CubeFatherActions();
    }

    private void FixedUpdate()
    {
        DisableRbPhysics();

    }

    private void CubeFatherActions()
    {
        if (Input.GetKeyDown(GameConstants.KEY_CUBE_FATHER))
        {
            if (transform.parent == null)
                transform.SetParent(cubeFather);
            else
                transform.SetParent(null);
        }
    }

    private bool isGrounded()
    {
        Debug.DrawRay(transform.position, transform.up * -1, Color.red);
        return Physics.Raycast(transform.position, transform.up * -1, 0.1f);
    }

    private void DisableRbPhysics()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.inertiaTensor = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    /// <summary ="GetInput()">
    /// Obtiene los inputs
    /// </summary>
    private void GetInput()
    {
        vertical_axis = Input.GetAxis(GameConstants.VERTICAL);
        horizontal_axis = Input.GetAxis(GameConstants.HORIZONTAL);
    }

    /// <summary ="PlayerMove()">
    /// Movimiento del jugador
    /// </summary>
    private void PlayerMove()
    {
        Vector3 move =
            (Vector3.forward * vertical_axis * speed) + (Vector3.right * horizontal_axis * speed);
        Vector3 clampedMove = Vector3.ClampMagnitude(move, speed); // definiendo la magnitud maxima para la velocidad del personaje
        transform.Translate(move * Time.deltaTime);
    }

    /// <summary ="PlayerGravity()">
    /// Movimiento de caiga del jugador
    /// </summary>
    private void PlayerGravity()
    {
        if (isGrounded())
        {
            verticalSpeed = 0f;
            if (Input.GetKey(KeyCode.Space))
            {
                verticalSpeed = jumpForce;
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
    }
}