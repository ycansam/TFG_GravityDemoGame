using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManagerLevel1 : CounterManager
{
    public Transform cubo;

    private void Start()
    {
        InitCounter(initialTime);
    }
    private void Update()
    {
        MoveCubeUpside();
        RunCounter();
    }

    private void MoveCubeUpside()
    {

        if (actualTime <= 0f)
        {
            if (cubo.position.y <= 6f)
            {
                Vector3 posicion = cubo.position;
                posicion.y += 5f;
                cubo.position = posicion;
                return;
            }

        }
    }
}
