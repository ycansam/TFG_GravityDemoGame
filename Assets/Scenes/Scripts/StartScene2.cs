using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene2 : MonoBehaviour
{
    private void Awake()
    {
        LevelManager.isLevelCompleted = false;
    }
    void Start()
    {
        PlayerSuit.SetPlayerSuitOn();
    }
}
