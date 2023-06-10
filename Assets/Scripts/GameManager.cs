using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public float initialTime = 30f;
    public Transform cubo;
    private float actualTime;
    private bool activeCounter = true;
    void Start()
    {
        InitCounter(initialTime);
    }

    void Update()
    {
        if (activeCounter)
        {
            if (actualTime <= 0f)
            {
                activeCounter = false;
                actualTime = 0f;

                // Hacer que el cubo vaya hacia arriba
                Vector3 posicion = cubo.position;
                posicion.y += 5f;
                cubo.position = posicion;
                return;
            }
            LessCounter();
        }
    }

    private void InitCounter(float initialTime)
    {
        actualTime = initialTime;
    }
    private void LessCounter()
    {
        actualTime -= Time.deltaTime;
    }

}
