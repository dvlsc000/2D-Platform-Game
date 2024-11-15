using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to rigidbody component
    private Animator anim; // Reference to animator component
    [SerializeField] private AudioSource deathSound; // Reference to audio source
    [SerializeField] private Image[] lifeHearts; // Array of heart images
    [SerializeField] private Text pineappleText; // Reference to the UI text
    private static int life = 3; // Assuming you want to start with 5 lives
    private bool isDead = false; // Flag to check if player is already dead

    void Start()
    {
        // Initialize components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InitializeLives(); // Initialize lives at start
    }

    // Called when the player collides with trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with spikes, enemy, or saw and is not already dead
        // Without !isDead, if player touches 2 spikes, dies twice instead of once
        if ((collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Saw")) && !isDead)
        {
            Die();
        }
    }

    // Method to handle player detah
    private void Die()
    {
        if (!isDead)
        {
            isDead = true; // Set isDead to true to prevent multiple deaths
            deathSound.Play(); // Play the sound
            rb.bodyType = RigidbodyType2D.Static; // Set rigidbody to freeze
            anim.SetTrigger("death"); // Trigger death animation
            Invoke("RestartLevel", 2f); // Delay to allow death animation and sound
        }
    }

    // Method to restart the current level
    private void RestartLevel()
    {
        if (life > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
            life--; // Decrease life count
            isDead = false; // Set the flag to false
            lifeHearts[life].enabled = false; // Disable one heart image
        }
        // Player has no more lifes, game over
        else
        {   
            life = 3; // Reset life count
            isDead = false; // Set the flag
            PlayerPrefs.SetString("ResultText", "YOU LOST"); // Display the text
            SceneManager.LoadScene(4); // Load the game over scene
            InitializeLives(); // Initialize lives for a new game
        }
    }

    // Method to initialize player lives UI
    private void InitializeLives()
    {
        // Enable the first 'life' number of hearts and disable the rest
        for (int i = 0; i < lifeHearts.Length; i++)
        {
            lifeHearts[i].enabled = i < life;
        }
    }
}
