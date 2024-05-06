using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public float spawnDelay = 2f; // Delay between enemy spawns
    public float spawnPadding = 1f; // Padding to ensure enemies spawn just offscreen

    private float minX, maxX, minY, maxY; // Screen boundaries

    void Start()
    {
        // Calculate the screen boundaries
        CalculateScreenBoundaries();

        // Start spawning enemies at intervals
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    void CalculateScreenBoundaries()
    {
        // Get the screen boundaries
        minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
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

        // Spawn the enemy at the random position
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}
