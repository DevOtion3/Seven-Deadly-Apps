using UnityEngine;

public class SlothAI : MonoBehaviour
{
    public Transform playerTransform;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float fixedXRotation = -87f; // Desired fixed X rotation
    public float movementSpeed = 3f; // Speed at which the boss moves towards the player

    private void Update()
    {
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

    private void AttackPlayer()
    {
        // Implement your attack logic here
        Debug.Log("Sloth boss is attacking!");
    }
}
