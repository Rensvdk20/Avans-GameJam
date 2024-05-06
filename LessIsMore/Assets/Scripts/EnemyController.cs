using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Movement speed of the enemy
    private Transform player; // Reference to the player's transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player GameObject and get its transform
    }

    void Update()
    {
        // Calculate the direction towards the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize(); // Normalize the direction vector to ensure consistent movement speed

        // Move the enemy towards the player
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
