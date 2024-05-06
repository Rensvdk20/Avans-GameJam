using UnityEngine;
using UnityEngine.Events;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage = 1f; // Damage inflicted by the bullet
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Check if the collided object is an enemy
        {
            // Get the enemy's health component

            Destroy(other.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
            scoreManager.UpdateScore(10);
        }
    }
}
