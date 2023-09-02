using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetPosition : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.position = transform.position;
        }
    }
}
