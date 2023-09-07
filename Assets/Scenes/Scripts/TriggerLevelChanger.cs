using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelChanger : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreen;
    [SerializeField] private string levelName;

    [SerializeField] private List<GameObject> deletingObjects = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == Tags.PLAYER)
            ChangeLevel();
    }

    private void ChangeLevel()
    {
        PlayerPhone.SetPlayerPhoneOff();
        PlayerSuit.SetPlayerSuitOff();
        loadingScreen.LoadScreen(levelName);
        foreach (GameObject go in deletingObjects)
        {
            if (go != null)
                Destroy(go);
        }
    }
}
