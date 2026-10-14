
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction; 

    public float speed = 5f; // Player speed
    public float acceleration = 2f; // Player accelerates
    public float deceleration = 3f; // Player decelerates

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPlayer();
    }

    // Reset the player position and velocity
    public void ResetPlayer()
    {
        rb.linearVelocity = Vector2.zero; // Reset the player velocity
        transform.position = new Vector2(-21f, transform.position.y); // Reset the player position 
    }

    private void Update()
    {
        // Get input for horizontal movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        float targetSpeed = direction.x * speed; // Calculate the target speed based on input and player speed
        float newSpeed; // New speed after applying acceleration or deceleration

        // Apply acceleration or deceleration based on input
        if (direction == Vector2.zero)
        {
            newSpeed = 0f;
        }
        else
        {
            newSpeed = Mathf.MoveTowards(
                rb.linearVelocity.x,
                targetSpeed,
                acceleration * Time.fixedDeltaTime
            );
        }

        rb.linearVelocity = new Vector2(
            newSpeed,
            rb.linearVelocity.y
        );
    }
}