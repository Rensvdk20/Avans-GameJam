using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage = 1f; // Damage inflicted by the bullet

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Check if the collided object is an enemy
        {
            // Get the enemy's health component

            Destroy(other.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
