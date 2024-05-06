using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public float growthAmount = 0.5f; // Amount by which the player scales up when picking up an item

    private Rigidbody2D rb; // Reference to the player's Rigidbody component
    private Vector2 movement; // Stores the player's movement input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
    }

    void Update()
    {
        // Input handling
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
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
}
