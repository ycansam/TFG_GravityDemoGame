using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private bool isRotating = false;
    public bool IsRotating
    {
        get { return this.isRotating; }
        private set { this.isRotating = value; }
    }

    void Start() { }

    // Update is called once per frame
    void Update() { }
}
