using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://github.com/codinginflow/2DPlatformerBeginner/blob/master/Assets/Scripts/StickyPlatform.cs
public class StayOnPlatform : MonoBehaviour
{
    // Following methods are used to implement mechanism where the player character sticks to a moving platform when
    // When it collides with it and detaches from the platform when it exits the collision area
    // Called when a 2D collider enters trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if colliding object is tagged as "Player"
        if (collision.gameObject.name == "Player")
        {
            // Set the player object's parent to the platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Called when a 2D collider enters trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the colliding object is named "Player"
        if (collision.gameObject.name == "Player")
        {
            // Remove the player object's parent, making it independent
            collision.gameObject.transform.SetParent(null);
        }
    }

 
}
