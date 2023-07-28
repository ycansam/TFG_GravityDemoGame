using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGravity : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes;
    private List<Gravity> cubesGravity = new List<Gravity>();
    public bool useGravity = true;
    private void Start()
    {
        foreach (GameObject item in cubes)
        {
            Debug.Log(item);
            cubesGravity.Add(item.GetComponent<Gravity>());
        }
    }

    public void DisableCubesGravity()
    {
        foreach (Gravity cubeG in cubesGravity)
        {
            cubeG.UseGravity(false);
        }
    }
    public void EnableCubesGravity()
    {
        foreach (Gravity cubeG in cubesGravity)
        {
            cubeG.UseGravity(true);
        }
    }
}
