using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileLifespan = 2f;
    public float fireCooldown = 0.5f;
    private bool canFire = true; // Flag to control firing rate

    void Update()
    {
        if (canFire && Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        if (firePoint == null || projectilePrefab == null)
        {
            Debug.LogError("Fire point or projectile prefab is not assigned!");
            return;
        }

        // Set canFire flag to false to prevent rapid firing
        canFire = false;

        // Calculate direction towards cursor position
        var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        var groundPlane = new Plane(Vector3.up, transform.position);
        
        var cursorPosition = Vector3.zero;
        if (groundPlane.Raycast(cameraRay, out var rayLength))
            cursorPosition = cameraRay.GetPoint(rayLength);
        var direction = (cursorPosition - firePoint.position).normalized;
        direction.y = 0f;

        // Instantiate the projectile at the fire point with an offset on the y-axis
        Vector3 spawnPosition = firePoint.position + new Vector3(0, 3, 0);
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.Euler(new Vector3(-90, 0, 0)));

        // Set projectile direction and speed
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }

        // Destroy the projectile after the specified lifespan
        Destroy(projectile, projectileLifespan);

        // Start a coroutine to reset canFire after the cooldown period
        StartCoroutine(ResetFireFlag());
    }

    IEnumerator ResetFireFlag()
    {
        // Wait for the cooldown period before allowing the player to fire again
        yield return new WaitForSeconds(fireCooldown);

        // Reset the canFire flag to true to allow firing again
        canFire = true;
    }
}
