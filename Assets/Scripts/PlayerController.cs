using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    // componentes
    private CharacterController characterController;

    [Header("Move Settings")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [Header("Variables")]
    private bool grounded = false;

    private float vertical_axis;
    private float horizontal_axis;

    private float gravity;
    private float verticalSpeed;


    /// <EstaticosParaOtrasClases>
    public static float ActualSpeed
    {
        get => actualSpeed;
    }
    private static float actualSpeed;

    // weight que indica la cantidad de animacion se aplica cuando se sprinta (de 0 a 1)
    public static float SprintWeight
    {
        get => sprintWeight;
    }
    private static float sprintWeight;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravity = GameConstants.PLAYERS_GRAVITY;
    }

    void Update()
    {
        GetInput();

        PlayerMove();
    }

    private void FixedUpdate()
    {
        PlayerGravity();
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
            (transform.forward * vertical_axis * speed)
            + (transform.right * horizontal_axis * speed);
        Vector3 clampedMove = Vector3.ClampMagnitude(move, speed); // definiendo la magnitud maxima para la velocidad del personaje
        characterController.Move(clampedMove * Time.deltaTime);
    }

    /// <summary ="PlayerGravity()">
    /// Movimiento de caiga del jugador
    /// </summary>
    private void PlayerGravity()
    {
        if (grounded)
        {
            verticalSpeed = -gravity * Time.fixedDeltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpForce;
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.fixedDeltaTime;
        }
        characterController.Move((transform.up * verticalSpeed) * Time.fixedDeltaTime);
        grounded = characterController.isGrounded;
    }
}
