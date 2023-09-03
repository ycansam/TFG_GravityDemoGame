using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGravity : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes;
    private List<Gravity> cubesGravity = new List<Gravity>();
    public bool useGravity = true;
    private bool activated;
    [SerializeField]
    private Transform activatedPoint;

    [SerializeField]
    private Transform desactivatedPoint;
    private void Start()
    {
        foreach (GameObject item in cubes)
        {
            if (item != null)
                cubesGravity.Add(item.GetComponent<Gravity>());
        }
    }

    private void Update()
    {
        if (activated)
        {
            // Calculate the new position
            Vector3 newPosition = Vector3.Lerp(transform.position, activatedPoint.position, 2 * Time.deltaTime);

            // Move the object to the new position
            transform.position = newPosition;
        }
        else
        {
            // Calculate the new position
            Vector3 newPosition = Vector3.Lerp(transform.position, desactivatedPoint.position, 2 * Time.deltaTime);

            // Move the object to the new position
            transform.position = newPosition;
        }
    }

    public void DisableCubesGravity()
    {
        foreach (Gravity cubeG in cubesGravity)
        {
            cubeG.UseGravity(false);
        }
        useGravity = false;
        activated = true;
    }
    public void EnableCubesGravity()
    {
        foreach (Gravity cubeG in cubesGravity)
        {
            cubeG.UseGravity(true);
        }
        useGravity = true;
        activated = false;
    }
}
