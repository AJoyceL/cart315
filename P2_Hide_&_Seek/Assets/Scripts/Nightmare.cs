using UnityEngine;

public class Nightmare : MonoBehaviour
{
    public Transform player;

    // Movement speeds for patrolling and chasing
    [Header("Movement")]
    public float patrolSpeed = 1f;
    public float chaseSpeed = 2f;

    // Vision range and layer mask for detecting obstacles
    [Header("Vision")]
    public float visionRange = 8f;
    public LayerMask obstacleLayer;

    // Patrol points for the Nightmare to move between
    [Header("Patrol")]
    public Transform pointA;
    public Transform pointB;

    private Rigidbody2D rb;
    private Transform targetPoint;
    private bool chasing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        targetPoint = pointB;
    }

    private void Update()
    {
        chasing = CanSeePlayer();
    }

    // Check if the Nightmare can see the player
    private bool CanSeePlayer()
    {
        // If the player is not assigned, return false
        if (player == null){
            return false;
        }
            
        // Calculate the direction and distance to the player
        Vector2 origin = transform.position;
        Vector2 target = player.position;
        Vector2 direction = target - origin;
        float distance = direction.magnitude;

        // If the player is out of vision range, return false
        if (distance > visionRange){
            return false;
        }

        // Cast a straight line toward the player.
        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            direction.normalized,
            distance,
            obstacleLayer
        );

        // The player is visible if no obstacle blocks the line.
        return hit.collider == null;
    }

    private void FixedUpdate()
    {
        // Move the Nightmare based on whether it is chasing the player or patrolling
        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    // Move the Nightmare towards the player
    private void ChasePlayer()
    {
        float difference = player.position.x - transform.position.x;

        // Only move horizontally.
        float horizontalDirection = Mathf.Sign(difference);

        // Stop horizontal movement when directly aligned.
        if (Mathf.Abs(difference) < 0.1f)
            horizontalDirection = 0f;

        rb.linearVelocity = new Vector2(
            horizontalDirection * chaseSpeed,
            rb.linearVelocity.y
        );
    }

    // Move the Nightmare between two patrol points
    private void Patrol()
    {
        float difference = targetPoint.position.x - transform.position.x;
        float horizontalDirection = Mathf.Sign(difference);

        rb.linearVelocity = new Vector2(
            horizontalDirection * patrolSpeed,
            rb.linearVelocity.y
        );

        if (Mathf.Abs(difference) < 0.2f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }
    }
}
