using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float delayBeforeDestory = 2f;

    private bool playerTouching = false;

    private void OnCollisionStay2D(Collision2D collision) 
    {
        // Check if the collidiong object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Set bool flag
            playerTouching = true;
            // Start Coroutine for destroying the platform
            StartCoroutine(DestroyPlatform());
        }
    }
    
    // Stop of collision with another collider
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if collidiong object is player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Set bool falg to false
            playerTouching = false;
        }
    }

    // Coroutine to detroy platform after spciefied delay
    private IEnumerator DestroyPlatform()
    {
        // Wait for specified delay
        yield return new WaitForSeconds(delayBeforeDestory);

        if (playerTouching)
        {
            Destroy(gameObject); // Destroy the platform
        }

    }
}
