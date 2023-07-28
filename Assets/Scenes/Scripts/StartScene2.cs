using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene2 : MonoBehaviour
{
    [SerializeField] private Transform initalPlayerPos;

    private void Awake()
    {
        LevelManager.isLevelCompleted = false;
    }
    void Start()
    {
        ResetPlayerStats();
    }

    private void ResetPlayerStats()
    {
        PlayerSuit.SetPlayerSuitOn();
        GameObject player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        player.transform.rotation = initalPlayerPos.rotation;
        player.transform.position = initalPlayerPos.position;
    }

}
