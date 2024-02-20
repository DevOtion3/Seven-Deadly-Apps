using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 3f;

    private Animator animator;
    private bool isWalking = false;
    private bool isRunning = false;
    private bool isIdle = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Determine if the player is moving
        bool isMoving = moveDirection.magnitude > 0;

        // Set movement animation parameters
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isIdle", isIdle);

        // Check if the player is running
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            isWalking = false;
            isRunning = true;
            isIdle = false;
        }
        // Check if the player is walking
        else if (isMoving)
        {
            isWalking = true;
            isRunning = false;
            isIdle = false;
        }
        // If the player is not moving, idle animation
        else
        {
            isWalking = false;
            isRunning = false;
            isIdle = true;
        }

        // Move the player
        float moveSpeed = isRunning ? runSpeed : walkSpeed;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
