using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Transform target; // R�f�rence � l'ennemi ou au curseur

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Calcul de la direction
            Vector3 direction;
            if (target != null)
            {
                // Si une cible est d�finie, diriger le projectile vers la cible
                direction = (target.position - transform.position).normalized;
            }
            else
            {
                // Si aucune cible n'est d�finie, diriger le projectile vers le curseur de la souris
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = (mousePosition - transform.position).normalized;
            }

            // Cr�ation du projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Obtention du composant Rigidbody2D du projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Application de la vitesse au projectile dans la direction calcul�e
                rb.velocity = direction * projectileSpeed;
            }
            else
            {
                Debug.LogWarning("Le projectile ne poss�de pas de composant Rigidbody2D.");
            }
        }
    }
}


