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
                else
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
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;

        }
    }

    private void UseGravity()
    {
        if (useGravity)
        {
            // Vector3 speedVectorized = actualDirection * verticalSpeed * Time.fixedDeltaTime;

            // transform.position += speedVectorized;
            // verticalSpeed -= gravity * Time.fixedDeltaTime * mass;
        }


        if (!IsGrounded())
        {
            rb.AddForce(Vector3.down * gravity * mass, ForceMode.Acceleration);
            Debug.Log("a");
        }
        else
        {
            Debug.Log("b");
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
        }
    }

    private bool IsGrounded()
    {
        Vector3 origin = transform.position;
        origin.y += 0.1f;
        float distance = 0.30f;
        RaycastHit hit;
        if (Physics.SphereCast(origin, 0.5f, Vector3.down, out hit, distance, groundLayers))
        {
            rb.constraints = RigidbodyConstraints.None;
            return true;
        }
        return false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Rigidbody>())
        {
            rb.velocity = Vector3.zero;
        }
    }
    // private void OnCollisionStay(Collision other)
    // {
    //     // Condiciones de choque de Alturas
    //     if (actualDirection == Vector3.up)
    //         OnCollisionEnterWithObjectMovable(other, other.transform.position.y, transform.position.y);
    //     if (actualDirection == Vector3.down)
    //         OnCollisionEnterWithObjectMovable(other, transform.position.y, other.transform.position.y);

    //     // Condiciones de choque de Anchura
    //     if (actualDirection == Vector3.right)
    //         OnCollisionEnterWithObjectMovable(other, other.transform.position.x, transform.position.x);
    //     if (actualDirection == Vector3.left)
    //         OnCollisionEnterWithObjectMovable(other, transform.position.x, other.transform.position.x);

    //     // Condiciones de choque de profundidad
    //     if (actualDirection == Vector3.forward)
    //         OnCollisionEnterWithObjectMovable(other, other.transform.position.z, transform.position.z);
    //     if (actualDirection == Vector3.back)
    //         OnCollisionEnterWithObjectMovable(other, transform.position.z, other.transform.position.z);

    //     OnCollisionEnterWithWall(other);
    // }

    // private void OnCollisionEnterWithObjectMovable(Collision other, float pos1, float pos2)
    // {


    //     if (other.transform.tag == Tags.OBJECT_MOVABLE_TAG)
    //     {
    //         //  Si los cubos estan en contacto en la misma altura
    //         if (
    //             pos1 < pos2 + 2f
    //             && pos1 > pos2 - 2f && !cubeController.IsRotating
    //         )
    //         {

    //         }
    //         // si el el cubo de pos2 esta por encima de cubo pos1
    //         // el cubo del script es pos2
    //         else if (pos1 < pos2)
    //         {

    //             // Debug.Log(Vector3.Angle(other.contacts[0].normal, actualDirection));
    //             // Debug.Log(Vector3Int.RoundToInt(other.transform.localEulerAngles));
    //             // Debug.Log(Vector3Int.RoundToInt(transform.localEulerAngles));
    //             if (
    //                 Vector3.Angle(other.contacts[0].normal, actualDirection) > 5f
    //                 && Vector3.Angle(other.contacts[0].normal, actualDirection) < 75
    //             )
    //             {
    //                 // La velocidad en la que cae estando encima del cubo y en un lado
    //                 if (!cubeController.IsRotating)
    //                 {
    //                     verticalSpeed = 0;
    //                     SetSpeedDirection(4f);
    //                 }

    //             }
    //             else if (Vector3.Angle(other.contacts[0].normal, actualDirection) < 5f)
    //             {
    //                 Gravity otherGravity = other.transform.GetComponent<Gravity>();

    //                 //  Si los cubos se tocan en plena caida no reinician la velocidad y el cubo que esta arriba adopta la velocidad del que esta abajo
    //                 if (otherGravity.verticalSpeed < -3f)
    //                 {
    //                     verticalSpeed = otherGravity.verticalSpeed;
    //                 }
    //                 //  Si el cubo que esta en la parte superior tiene alguna rotacion en la que no esta completamente plano se aplica una velocidad
    //                 else if ((int)transform.localEulerAngles.x % 90 != 0 || (int)transform.localEulerAngles.y % 90 != 0 || (int)transform.localEulerAngles.z % 90 != 0)
    //                 {
    //                     if ((int)transform.localEulerAngles.x % 90 == 0 || (int)transform.localEulerAngles.y % 90 == 0 || (int)transform.localEulerAngles.z % 90 == 0)
    //                     {
    //                         ResetSpeeds();
    //                     }
    //                     else
    //                     {
    //                         verticalSpeed = 0;
    //                         SetSpeedDirection(4f);
    //                     }
    //                 }
    //                 else
    //                 {
    //                     ResetSpeeds();
    //                 }

    //             }
    //         }
    //         // Si el cubo de pos1 esta por encima de pos2
    //         else if (pos1 > pos2)
    //         {
    //             SetSpeedDirection();
    //         }
    //         LimitSpeed();
    //     }
    // }
    // private void ResetSpeeds()
    // {
    //     verticalSpeed = 0;
    //     rb.velocity = Vector3.zero;
    //     rb.angularVelocity = Vector3.zero;
    // }

    // private void OnCollisionEnterWithWall(Collision other)
    // {
    //     if (other.transform.tag == Tags.CUBEWALL_TAG)
    //     {
    //         if (other.contacts.Length > 0)
    //         {
    //             // Compruebo que el choque esta en fuera de 85 y 95 grados para que se aplique la gravedad
    //             // fuera 85 y 95 para evitar errores en caso de que hubiese, se aplica la gravedad si el contacto es de 90º
    //             if (
    //                 Vector3.Angle(other.contacts[0].normal, actualDirection) > 50
    //                 && Vector3.Angle(other.contacts[0].normal, actualDirection) < 135
    //             )
    //             {
    //                 //  si esta en 90 grados se deja caer
    //                 LimitSpeed();

    //             }
    //             else
    //             {
    //                 ResetSpeeds();
    //                 // Si esta tocando el suelo y cae en diagonal caera mas rapido para poner la normal igual al suelo
    //                 SetSpeedDirection(5f);
    //             }
    //         }
    //     }
    // }
    // Limita la velocidad de caida
    private void LimitSpeed()
    {
        float maxSpeed = 20f;

        if (verticalSpeed <= -maxSpeed)
        {
            verticalSpeed = -maxSpeed;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void SetSpeedDirection(float vel = 3f)
    {
        rb.angularVelocity = Vector3.zero;
        if (verticalSpeed > -0.6f)
        {
            if (actualDirection == Vector3.up)
                rb.velocity = Vector3.down * vel;
            else if (actualDirection == Vector3.right)
                rb.velocity = Vector3.left * vel;
            else if (actualDirection == Vector3.left)
                rb.velocity = Vector3.right * vel;
            else if (actualDirection == Vector3.down)
                rb.velocity = Vector3.up * vel;
            else if (actualDirection == Vector3.forward)
                rb.velocity = Vector3.back * vel;
            else if (actualDirection == Vector3.back)
                rb.velocity = Vector3.forward * vel;
        }
    }

}
