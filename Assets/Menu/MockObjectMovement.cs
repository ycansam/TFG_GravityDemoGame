using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockObjectMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;
    public bool straightMove = false;

    private int currentWaypoint = 0;

   
    void Update()
    {
        // Check if the object has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypoint++;

            // If we reached the last waypoint, reset to the first
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        // Move towards the current waypoint
        if (straightMove)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            return;
        }
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
