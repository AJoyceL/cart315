
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direction; 

    public float speed = 2f; // Player speed
    // public float acceleration = 2f;// Player acceleration

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
        direction = 0f; 

        // Get input for horizontal movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            direction = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){

            direction = 1f;
        }
    }

    private void FixedUpdate()
    {
        // Move the player based on input direction
        float targetSpeed = direction * speed;
        float currentSpeed = direction == 0f ? 0f : Mathf.MoveTowards(rb.linearVelocity.x, targetSpeed, speed * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
    }
}