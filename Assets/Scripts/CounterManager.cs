using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CounterManager : MonoBehaviour
{
    public float initialTime = 30f;
    public Transform cubo;
    private float actualTime;
    private bool activeCounter = true;
    [SerializeField] TextMesh text;
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
        text.text = actualTime.ToString();
    }
    private void LessCounter()
    {
        actualTime -= Time.deltaTime;
        text.text = actualTime.ToString("F2");
    }

}
