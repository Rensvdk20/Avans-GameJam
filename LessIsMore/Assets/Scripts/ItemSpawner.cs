using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // Reference to the enemy prefab to spawn
    public float spawnDelay = 2f; // Delay between enemy spawns
    public float spawnPadding = 1f; // Padding to ensure enemies spawn just offscreen

    void Start()
    {
        // Start spawning enemies at intervals
        InvokeRepeating("SpawnItem", 0f, spawnDelay);
    }
    void SpawnItem()
    {
        // Get the screen boundaries
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        // Calculate a random position just offscreen
        Vector3 randomPosition = new Vector3(
            Random.Range(minX + spawnPadding, maxX - spawnPadding),
            Random.Range(minY + spawnPadding, maxY - spawnPadding),
            0f
        );

        // Spawn the item at the random position
        Instantiate(itemPrefab, randomPosition, Quaternion.identity);
    }
}
