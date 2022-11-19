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
        }
    }

    private void UseGravity()
    {
        if (useGravity)
        {
            verticalSpeed -= gravity * Time.fixedDeltaTime;
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + (verticalSpeed * Time.fixedDeltaTime) * mass,
                transform.position.z
            );
            // transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        OnCollisionEnterWithWall(other);
    }

    private void OnCollisionEnterWithWall(Collision other)
    {
        if (
            other.transform.tag == Tags.CUBEWALL_TAG
            || other.transform.tag == Tags.OBJECT_MOVABLE_TAG
        )
        {
            if (other.contacts.Length > 0)
            {
                // Compruebo que el choque esta en fuera de 85 y 95 grados para que se aplique la gravedad
                // fuera 85 y 95 para evitar errores en caso de que hubiese, se aplica la gravedad si el contacto es de 90º
                if (
                    Vector3.Angle(other.contacts[0].normal, Vector3.up) > 85
                    && Vector3.Angle(other.contacts[0].normal, Vector3.up) < 95
                ) { }
                else
                {
                    if (other.transform.position.y < transform.position.y)
                    {
                        verticalSpeed = 0;
                        rb.velocity = Vector3.zero;
                    }
                    print(other.contacts.Length);
                }
                // print( Vector3.Angle(other.contacts[0].normal, Vector3.up));
            }
            if (other.contacts.Length > 6)
            {
                verticalSpeed = 0;
                rb.velocity = Vector3.zero;
            }
        }
    }
}
