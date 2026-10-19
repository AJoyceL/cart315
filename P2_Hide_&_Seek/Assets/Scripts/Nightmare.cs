using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nightmare : MonoBehaviour
{
    private gameManager gameManager;
    private Player Player;

    public Transform player;

    // Movement speeds for patrolling and chasing
    [Header("Movement")]
    public float patrolSpeed = 10f;
    public float chaseSpeed = 15f;

    // Vision range and layer mask for detecting obstacles
    [Header("Vision")]
    public float visionRange = 8f;
    public LayerMask obstacleLayer;

    // Patrol points for the Nightmare to move between
    [Header("Patrol")]
    public Transform pointA;
    public Transform pointB;
    public float patrolEndX = 24f;

    private Rigidbody2D rb;
    private int patrolDirection = 1;
    private bool chasing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetMonster();

        Player = player.GetComponent<Player>();

        if (Player == null)
        {
            Debug.LogError("Player script not found!");
        }
    }

    public void ResetMonster()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Nightmare: Assign Point A and Point B in the Inspector!");
            return;
        }

        rb.position = pointA.position;
        rb.linearVelocity = Vector2.zero;
        patrolDirection = 1;
    }
    
    private void Update()
    {
        chasing = CanSeePlayer();
    }

    // Check if the Nightmare can see the player

    public bool CanSeePlayer()
    {
        if (player == null)
            return false;

        Vector2 origin = transform.position;
        Vector2 target = player.position;
        Vector2 direction = target - origin;
        float distance = direction.magnitude;

        if (distance > visionRange)
            return false;

        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            direction.normalized,
            distance,
            obstacleLayer
        );

        // A wall blocks the Nightmare's vision.
        if (hit.collider != null)
        {
            Debug.Log("Vision blocked by: " + hit.collider.name);
            return false;
        }

        return true;
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
        if (Mathf.Abs(difference) < 0.1f){
            horizontalDirection = 0f;
        }

        rb.linearVelocity = new Vector2(horizontalDirection * chaseSpeed, rb.linearVelocity.y);

        Vector2 direction = (player.position - transform.position).normalized;
    }

    // Move the Nightmare between two patrol points
    private void Patrol()
    {
        float targetX = patrolDirection == 1
            ? patrolEndX
            : pointA.position.x;

        float currentX = rb.position.x;

        // Turn around when the monster reaches its target
        if (patrolDirection == 1 && currentX >= targetX ||
            patrolDirection == -1 && currentX <= targetX)
        {
            patrolDirection *= -1;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float direction = Mathf.Sign(targetX - currentX);
        rb.linearVelocity = new Vector2(direction * patrolSpeed, 0f);
    }

    public bool CanCatchPlayer()
    {
        return CanSeePlayer();
    }
}
