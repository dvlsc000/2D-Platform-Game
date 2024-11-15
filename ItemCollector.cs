using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pineapples = 0; // Counter for collected pineapples
    [SerializeField] private Text pineappleText; // Reference to UI text component
    [SerializeField] private AudioSource collectSound; // Sound playing when collecting objects
    // Array to hold objects to destroy
    [SerializeField] private GameObject[] objectsToDestroy; // Array of object to be destroyed
      private int nextObjectIndex = 0; // Index of next object to be destroyed
    private Player_Movement playerMovement; // Reference to Player_Movement script


    private void Start()
    {
        // Reference to Player_Movement script
        playerMovement = GetComponent<Player_Movement>() ?? FindObjectOfType<Player_Movement>();
    }
    // When player collides with trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collision is with pineapple
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectSound.Play(); // Play the sound
            Destroy(collision.gameObject); // Destroy the object
            pineapples++; // Increase the count

            // Check for the power up
            if (pineapples % 4 == 0) // Every 4 pineapples
            {
                if (playerMovement != null)
                {
                    StartCoroutine(DoubleSpeedTemporarily()); // Double player's movement speed
                    pineapples = 0; // Reset the counter
                }
            }
            pineappleText.text = pineapples.ToString(); // Update UI text
        }

        // If collision is with object Key
        if (collision.gameObject.CompareTag("Key"))
        {
            collectSound.Play(); // Play the sound
            Destroy(collision.gameObject); // Destroy the object
            DestroyNextObject(); // Destroy the next object in the array of the objects to be destroyed
        }

        // If collision is with object Speedy
        if (collision.gameObject.CompareTag("Speedy"))
        {
            if (playerMovement != null)
            {
                StartCoroutine(SlowSpeedTemporarily()); // Slow down player's movement speed
                Destroy(collision.gameObject); // Destory the object
            }
        }
    }

    // Method to destroy the next object in the objectsToDestroy array
     private void DestroyNextObject()
    {
        if (nextObjectIndex < objectsToDestroy.Length)
        {
            Destroy(objectsToDestroy[nextObjectIndex]); // Destroy the next object
            nextObjectIndex++; // Increment the index for the next object
        }
    }

    // Coroutine to temporarily double the player's speed
    private IEnumerator DoubleSpeedTemporarily()
    {
        float originalSpeed = playerMovement.moveSpeed; // Store the original speed
        playerMovement.moveSpeed *= 1.5f; // Double the speed

        yield return new WaitForSeconds(10); // Wait for 10 seconds

        playerMovement.moveSpeed = originalSpeed; // Reset the speed to its original value
    }

    // Coroutine to temporarily slow down the player's speed
    private IEnumerator SlowSpeedTemporarily()
    {
        float originalSpeed = playerMovement.moveSpeed; // Store the original speed
        playerMovement.moveSpeed *= 0.5f; // Double the speed

        yield return new WaitForSeconds(5); // Wait for 5 seconds

        playerMovement.moveSpeed = originalSpeed; // Reset the speed to its original value
    }
}
