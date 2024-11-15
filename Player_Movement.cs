using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for the EventSystem

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to Rigidbody 2d
    private Animator anim; // Reference to animator
    private SpriteRenderer sr; // Reference to sprite renderer
    private BoxCollider2D coll; // Reference to box collider

    // Enumeration for different movement states 
    private enum MovementState { idle, running, jumping, falling }

    private float directionX; // Horizontal movement input
    [SerializeField] public float moveSpeed = 7f; // Movement speed
    [SerializeField] private float jumpForce = 14f; // Jump force
    [SerializeField] private LayerMask jumpableGround; // Layer mask for jumpable ground
    [SerializeField] private AudioSource jumpSound; // Reference to audio source

    // Variables to handle button-based movement
    private bool moveLeft = false;
    private bool moveRight = false;

    private void Start()
    {
        // Initialize references for components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Handle movement direction based on both keyboard and button inputs
        directionX = 0f;
        if (moveLeft)
        {
            directionX -= 1f;
        }
        if (moveRight)
        {
            directionX += 1f;
        }
        
        // Add keyboard input to directionX
        directionX += Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        // Check for jump input and ground contact to jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        // Update player animation based on movement and velocity
        UpdateAnimation();
    }

    // Method to handle player jump
    public void Jump()
    {
        // Check if player is grounded
        if (IsGrounded())
        {
            jumpSound.Play(); // Play the sound
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply vertical force
        }
    }

    // Reference: https://github.com/codinginflow/2DPlatformerBeginner/blob/master/Assets/Scripts/PlayerMovement.cs
    // Update player's animation based on movement and velocity
    private void UpdateAnimation()
    {
        MovementState state; // State variable to control the animations

        // If the player object is moving -> Running animation
        if (directionX > 0f)
        {
            state = MovementState.running;
            sr.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sr.flipX = true;
        }

        // If the player object is not moving -> Idle animation
        else
        {
            state = MovementState.idle;
        }

        // Player jumping animation 
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        // Player falling animation
        else if (rb.velocity.y < -.1)
        {
            state = MovementState.falling;
        }

        // Update animator with the current movement state
        anim.SetInteger("state", (int)state);
    }

    // Handle collision with trampoline
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            anim.SetBool("trampoline", true); // Set trampoline animation parameter
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 2); // Apply increased jump force
        }
    }

    // Check if player is grounded using boxcast
    // Reference: https://discussions.unity.com/t/how-do-i-get-my-2d-boxcast-to-work-why-is-my-2d-boxcast-not-working/257019
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

     // Methods to handle movement with UI buttons
    public void StartMovingLeft()
    {
        moveLeft = true; // Set left movement flag
    }

    // Requierd in order to use buttons for movement
    public void StopMovingLeft()
    {
        moveLeft = false; // Reset left movement flag
    }

    public void StartMovingRight()
    {
        moveRight = true; // Set left movement flag
    }

    public void StopMovingRight()
    {
        moveRight = false; // Reset left movement flag
    }
}
