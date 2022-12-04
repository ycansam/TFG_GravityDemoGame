using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    // componentes
    private CharacterController characterController;

    [SerializeField]
    private CubeController cubeController;
    private Rigidbody rb;

    [Header("Move Settings")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool gravityEnabled;

    [Header("Variables")]
    private bool grounded = false;

    private float vertical_axis;
    private float horizontal_axis;

    private float gravity;
    private float verticalSpeed;

    private Vector3 normalDir;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravity = GameConstants.PLAYERS_GRAVITY;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        PlayerMove();
        if (gravityEnabled)
            PlayerGravity();
    }

    private void FixedUpdate()
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
        // characterController.Move(clampedMove * Time.deltaTime);
        transform.Translate(move * Time.deltaTime);
    }

    /// <summary ="PlayerGravity()">
    /// Movimiento de caiga del jugador
    /// </summary>
    private void PlayerGravity()
    {
        if (grounded)
        {
            verticalSpeed = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpForce;
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        if (verticalSpeed < -10f)
        {
            verticalSpeed = -10f;
        }
        grounded = characterController.isGrounded;
        print(grounded);
        // transform.Translate(transform.up * verticalSpeed * Time.deltaTime);
        // characterController.Move((playerPos.up * verticalSpeed) * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit.normal);
        print(transform.up);
        normalDir = hit.normal;
    }
}
