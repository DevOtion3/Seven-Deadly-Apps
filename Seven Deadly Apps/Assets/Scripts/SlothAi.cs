using System;
using UnityEngine;

public class SlothAI : MonoBehaviour
{
    public Transform playerTransform;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float fixedXRotation = 0f; // Desired fixed X rotation
    public float movementSpeed = 3f; // Speed at which the boss moves towards the player

    private bool isAttacking = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the boss is not already attacking
        if (!isAttacking)
        {
            if (DialogueManager.instance.IsInDialogue())
            {
                anim.Play("SlothIdle");
                movementSpeed = 0;
            }
            else
            {
                anim.Play("SlothWalk");
                movementSpeed = 3;
            }

            // Check if the player is within detection range
            float distanceToPlayer = Vector3.Distance(new Vector3(transform.position.x, 0f, transform.position.z), new Vector3(playerTransform.position.x, 0f, playerTransform.position.z));
            if (distanceToPlayer < detectionRange)
            {
                // Calculate the direction to the player, ignoring the Y-component
                Vector3 directionToPlayer = (new Vector3(playerTransform.position.x, 0f, playerTransform.position.z) - new Vector3(transform.position.x, 0f, transform.position.z)).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

                // Keep the X rotation fixed
                lookRotation.eulerAngles = new Vector3(fixedXRotation, lookRotation.eulerAngles.y, lookRotation.eulerAngles.z);

                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

                // Move towards the player, only changing the X and Z components
                transform.position += new Vector3(directionToPlayer.x, 0f, directionToPlayer.z) * movementSpeed * Time.deltaTime;

                // If the player is within attack range, attack
                if (distanceToPlayer < attackRange)
                {
                    AttackPlayer();
                }
            }
        }
    }

    private void AttackPlayer()
    {


        // Stop the boss's movement
        movementSpeed = 0f;

        // Set the isAttacking flag to true to prevent chasing while attacking
        isAttacking = true;

        // Wait for the attack animation to finish before allowing the boss to chase again
        Invoke("FinishAttack", 2.0f);
    }

    private void FinishAttack()
    {
        // Reset the isAttacking flag to allow chasing again
        isAttacking = false;

        // Resume chasing
        movementSpeed = 3f;
    }
}

