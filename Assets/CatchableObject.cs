using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableObject : MonoBehaviour
{
    public static CatchableObject instance;
    private void Awake()
    {
        KeepPlayerOnScene();
        
    }

    private void KeepPlayerOnScene()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
