using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // Speed at which the player moves
    [SerializeField] private Rigidbody2D rb;       // Reference to the Rigidbody2D component

    private Vector2 moveInput; // Variable to store player's input

    void Awake()
    {
        // Ensure rb is assigned via the Inspector, but assign it here if not
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component not found on this game object.");
            }
        }
    }

    void Update()
    {
        // Handle player input
        HandlePlayerInput();
    }

    void FixedUpdate()
    {
        // Move the player based on input
        HandlePlayerMovement();
    }

    private void HandlePlayerInput()
    {
        // Get input from the player and normalize it
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void HandlePlayerMovement()
    {
        // Apply the input to the player's Rigidbody2D to move
        rb.velocity = moveInput * moveSpeed;
    }
}
