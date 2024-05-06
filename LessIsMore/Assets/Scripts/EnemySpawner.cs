using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public float spawnDelay = 2f; // Delay between enemy spawns
    public float spawnPadding = 1f; // Padding to ensure enemies spawn just offscreen
    public float minSpeed = 2f; // Minimum speed of the enemy
    public float maxSpeed = 5f; // Maximum speed of the enemy

    void Start()
    {
        // Start spawning enemies at intervals
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    void SpawnEnemy()
    {
        // Determine a random edge of the screen
        int edgeIndex = Random.Range(0, 4); // 0: Top, 1: Bottom, 2: Left, 3: Right

        // Get the screen boundaries
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        // Calculate a random position just offscreen based on the chosen edge
        Vector3 randomPosition = Vector3.zero;

        switch (edgeIndex)
        {
            case 0: // Top edge
                randomPosition = new Vector3(Random.Range(minX, maxX), maxY + spawnPadding, 0f);
                break;
            case 1: // Bottom edge
                randomPosition = new Vector3(Random.Range(minX, maxX), minY - spawnPadding, 0f);
                break;
            case 2: // Left edge
                randomPosition = new Vector3(minX - spawnPadding, Random.Range(minY, maxY), 0f);
                break;
            case 3: // Right edge
                randomPosition = new Vector3(maxX + spawnPadding, Random.Range(minY, maxY), 0f);
                break;
        }
        // Calculate a random speed for the enemy within the specified range
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Instantiate the enemy prefab at the spawner's position with a random speed
        GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        // Get the enemy's movement script (replace "EnemyMovement" with your actual enemy movement script name)
        EnemyController enemyMovement = enemy.GetComponent<EnemyController>();

        // Set the enemy's speed to the random speed
        if (enemyMovement != null)
        {
            enemyMovement.moveSpeed = randomSpeed;
        }
        else
        {
            Debug.LogWarning("EnemyMovement script not found on enemy prefab.");
        }
        // Spawn the enemy at the random position
    }
}
