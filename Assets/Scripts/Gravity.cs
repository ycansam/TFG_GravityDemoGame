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

    [SerializeField]
    float mass = 1f;

    // Elementos usado en el script
    private Rigidbody rb;
    private float verticalSpeed;
    public float VerticalSpeed
    {
        get { return this.verticalSpeed; }
        private set { this.verticalSpeed = value; }
    }

    private void Awake()
    {
        // gravityReferencePoint = GameObject.Find("GravityReferencePoint");
        rb = gameObject.GetComponent<Rigidbody>();
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
            verticalSpeed -= gravity * Time.fixedDeltaTime * mass;
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + (verticalSpeed * Time.fixedDeltaTime),
                transform.position.z
            );
            // transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        OnCollisionEnterWithWall(other);
        OnCollisionEnterWithObjectMovable(other);
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
                    Vector3.Angle(other.contacts[0].normal, Vector3.up) > 50
                    && Vector3.Angle(other.contacts[0].normal, Vector3.up) < 130
                )
                {
                    //  si esta en 90 grados se deja caer
                    LimitSpeed();
                }
                else
                {
                    verticalSpeed = 0;
                    rb.velocity = Vector3.zero;
                }
                if (verticalSpeed > -0.6f)
                    rb.velocity = Vector3.down * 5f;

                // print(Vector3.Angle(other.contacts[0].normal, Vector3.up));
            }
        }
    }

    private void OnCollisionEnterWithObjectMovable(Collision other)
    {
        if (other.transform.tag == Tags.OBJECT_MOVABLE_TAG)
        {
            if (
                other.transform.position.y < transform.position.y + 2f
                && other.transform.position.y > transform.position.y - 2f
            )
            {
                rb.velocity = Vector3.zero;
            }
            else if (other.transform.position.y < transform.position.y)
            {
                if (
                    Vector3.Angle(other.contacts[0].normal, Vector3.up) > 5f
                    && Vector3.Angle(other.contacts[0].normal, Vector3.up) < 75
                )
                {
                    if (!cubeController.IsRotating)
                    {
                        verticalSpeed = 0;
                        rb.velocity = Vector3.down * 3f;
                    }
                    else
                    {
                        verticalSpeed = 0;
                        rb.velocity = Vector3.zero;
                    }
                }
                else if (Vector3.Angle(other.contacts[0].normal, Vector3.up) < 5f)
                {
                    verticalSpeed = 0;
                    rb.velocity = Vector3.zero;
                }
            }
            LimitSpeed();
        }
    }

    private void LimitSpeed()
    {
        if (verticalSpeed <= -17f)
        {
            verticalSpeed = -17f;
            rb.velocity = Vector3.zero;
        }
    }
}
