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
    private Rigidbody rb;
    private float verticalSpeed;
    private Transform player;
    private Vector3 actualDirection = Vector3.up;

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
                else
                    actualDirection = Vector3.up;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UseGravity();
    }

    private void UseGravity()
    {
        if (useGravity)
        {
            Vector3 speedVectorized = actualDirection * verticalSpeed * Time.fixedDeltaTime;

            transform.position += speedVectorized;
            verticalSpeed -= gravity * Time.fixedDeltaTime * mass;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        // Condiciones de choque de Alturas
        if (actualDirection == Vector3.up)
            OnCollisionEnterWithObjectMovable(other, other.transform.position.y, transform.position.y);
        if (actualDirection == Vector3.down)
            OnCollisionEnterWithObjectMovable(other, transform.position.y, other.transform.position.y);

        // Condiciones de choque de Anchura
        if (actualDirection == Vector3.right)
            OnCollisionEnterWithObjectMovable(other, other.transform.position.x, transform.position.x);
        if (actualDirection == Vector3.left)
            OnCollisionEnterWithObjectMovable(other, transform.position.x, other.transform.position.x);

        // Condiciones de choque de profundidad
        if (actualDirection == Vector3.forward)
            OnCollisionEnterWithObjectMovable(other, other.transform.position.z, transform.position.z);
        if (actualDirection == Vector3.back)
            OnCollisionEnterWithObjectMovable(other, transform.position.z, other.transform.position.z);

        OnCollisionEnterWithWall(other);
    }

    private void OnCollisionEnterWithObjectMovable(Collision other, float pos1, float pos2)
    {
        if (other.transform.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            //  Si los cubos estan en contacto en la misma altura
            if (
                pos1 < pos2 + 2f
                && pos1 > pos2 - 2f
            )
            {
                rb.velocity = Vector3.zero;
            }
            // si el el cubo de pos2 esta por encima de cubo pos1
            // el cubo del script es pos2
            else if (pos1 < pos2)
            {

                if (
                    Vector3.Angle(other.contacts[0].normal, actualDirection) > 5f
                    && Vector3.Angle(other.contacts[0].normal, actualDirection) < 75
                )
                {
                    if (!cubeController.IsRotating)
                    {
                        verticalSpeed = 0;
                        SetSpeedDirection();
                    }
                    else
                    {
                        ResetSpeeds();
                    }
                }
                else if (Vector3.Angle(other.contacts[0].normal, actualDirection) < 5f)
                {
                    ResetSpeeds();
                }
            }
            // Si el cubo de pos1 esta por encima de pos2
            else if (pos1 > pos2)
            {
                SetSpeedDirection();
            }
            LimitSpeed();
        }
    }
    private void ResetSpeeds()
    {
        verticalSpeed = 0;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnterWithWall(Collision other)
    {
        if (other.transform.tag == Tags.CUBEWALL_TAG)
        {
            if (other.contacts.Length > 0)
            {
                // Compruebo que el choque esta en fuera de 85 y 95 grados para que se aplique la gravedad
                // fuera 85 y 95 para evitar errores en caso de que hubiese, se aplica la gravedad si el contacto es de 90º
                if (
                    Vector3.Angle(other.contacts[0].normal, actualDirection) > 50
                    && Vector3.Angle(other.contacts[0].normal, actualDirection) < 130
                )
                {
                    //  si esta en 90 grados se deja caer
                    LimitSpeed();
                }
                else
                {
                    ResetSpeeds();
                }
                SetSpeedDirection();
            }
        }
    }
    // Limita la velocidad de caida
    private void LimitSpeed()
    {
        if (verticalSpeed <= -17f)
        {
            verticalSpeed = -17f;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void SetSpeedDirection()
    {
        if (verticalSpeed > -0.6f)
        {
            if (actualDirection == Vector3.up)
                rb.velocity = Vector3.down * 3f;
            else if (actualDirection == Vector3.right)
                rb.velocity = Vector3.left * 3f;
            else if (actualDirection == Vector3.left)
                rb.velocity = Vector3.right * 3f;
            else if (actualDirection == Vector3.down)
                rb.velocity = Vector3.up * 3f;
            else if (actualDirection == Vector3.forward)
                rb.velocity = Vector3.back * 3f;
            else if (actualDirection == Vector3.back)
                rb.velocity = Vector3.forward * 3f;
        }
    }

}
