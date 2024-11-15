using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    // Array of way points object should follow
    [SerializeField] private GameObject[] waypoints;
    // Movement speed of the object
    [SerializeField] private float speed = 2f;
    // Rotation speed of the object
    [SerializeField] private float rotationSpeed = 2f;
    // Index of current waypoint
    private int currentWayPointIndex = 0;
    // Indicates if object is moving forwards
    private bool movingForward = false;
    // Reference to sprite render component
    private SpriteRenderer sr;

    private void Start()
    {
        // Get the SpriteRenderer component attatched to the same object
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If the object is moving forward
        if (movingForward)
        {
            // If the object is close to current waypoint 
            if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
            {
                // Move to the next waypoint
                currentWayPointIndex++;
                // If end of waypoints reached
                if (currentWayPointIndex >= waypoints.Length)
                {
                    // Set the current waypoint index to the second last one
                    currentWayPointIndex = waypoints.Length - 2; 
                    // Change direction to backwards
                    movingForward = false;
                    // Flip the object horizontally
                    sr.flipX = !sr.flipX; 
                }
            }
        }
        // Moving backwards
        else 
        {
            // If the object is close to the current waypoint
            if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
            {
                // Move to the previous waypoint
                currentWayPointIndex--;
                // If reached beginning of waypoints
                if (currentWayPointIndex < 0)
                {
                    // Set the current waypoint index to the second one
                    currentWayPointIndex = 1; 
                    // Change direction to forward
                    movingForward = true;
                    // Flip the object horizontally
                    sr.flipX = !sr.flipX;
                }
            }
        }

        // Move the object towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);

        // If the object is tagged as "Saw"
        if (gameObject.tag == "Saw")
        {
            // Rotatate the object
            RotateObject();
        }
    }

    void RotateObject()
    {
        // Rotate the object around its Z-axis
        transform.Rotate(0, 0, 360 * rotationSpeed * Time.deltaTime);
    }
}
