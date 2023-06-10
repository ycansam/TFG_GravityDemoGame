using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelChanger : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PLAYER)
            ChangeLevel();
    }

    private void ChangeLevel()
    {
        loadingScreen.LoadScreen("Level2");
    }
}
