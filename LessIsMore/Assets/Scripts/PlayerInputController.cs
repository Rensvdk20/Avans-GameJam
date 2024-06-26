using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public float growthAmount = 0.5f; // Amount by which the player scales up when picking up an item

    private Rigidbody2D rb; // Reference to the player's Rigidbody component
    private Vector2 movement; // Stores the player's movement input
    public GameObject canvas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
    }

    void Update()
    {
        // Input handling
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f; // Resume the game
        }
    }

    void FixedUpdate()
    {
        // Movement logic
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item")) // Check if the collided object is an item
        {
            // Increase the scale of the player by the growth amount
            transform.localScale += new Vector3(growthAmount, growthAmount, 0f);

            // Destroy the item
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Check if the collided object is an enemy
        {
            // Call a method to handle player death
            HandlePlayerDeath();
        }
    }

    void HandlePlayerDeath()
    {
        Time.timeScale = 0f; // Pause the game
        canvas.SetActive(true);
    }


}
