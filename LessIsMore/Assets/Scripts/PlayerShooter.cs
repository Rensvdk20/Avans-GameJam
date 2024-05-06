using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab to shoot
    public Transform firePoint; // Reference to the transform representing the fire point
    public float bulletSpeed = 10f; // Speed of the bullet
    public int minPlayerSizeForShooting = 1; // Minimum player size required for shooting
    public float growthDecrease = 0.1f;

    void Update()
    {
        // Check if the player's size is greater than the minimum required size for shooting
        if (transform.localScale.x > minPlayerSizeForShooting && transform.localScale.y > minPlayerSizeForShooting)
        {
            // Check if the player pressed the custom fire button (spacebar)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Calculate the direction from the player to the mouse position
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 fireDirection = (mousePosition - transform.position).normalized;

                // Instantiate a bullet at the fire point position and rotation
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

                // Get the bullet's Rigidbody2D component
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                // Set the bullet's velocity to shoot towards the mouse position
                rb.velocity = fireDirection * bulletSpeed;

                transform.localScale -= new Vector3(growthDecrease, growthDecrease, 0f);
            }
        }
    }
}
