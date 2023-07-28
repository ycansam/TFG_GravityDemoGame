using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CounterManager : MonoBehaviour
{
    public float initialTime = 30f;
    protected float actualTime;
    protected bool activeCounter = true;
    [SerializeField] protected TextMesh text;
    protected void Start()
    {
        InitCounter(initialTime);
    }

    protected void RunCounter()
    {
        if (activeCounter)
        {
            if (actualTime <= 0f)
            {
                activeCounter = false;
                actualTime = 0f;
                return;
            }
            LessCounter();
        }
    }

    private void InitCounter(float initialTime)
    {
        actualTime = initialTime;
        if (text != null)
            text.text = actualTime.ToString();
    }
    private void LessCounter()
    {
        actualTime -= Time.deltaTime;
        if (text != null)
            text.text = actualTime.ToString("F2");
    }

}
