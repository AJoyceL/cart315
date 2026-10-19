
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    public float moveSpeed = 0.5f;

    private Snake snake;
    private Vector2 targetPosition;

    private void Awake()
    {
        snake = FindFirstObjectByType<Snake>();
    }

    private void Start()
    {
        RandomizePosition();
        PickRandomTarget();
    }

    private void Update()
    {
        // Move slowly toward the target
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // Pick a new target when reached
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            PickRandomTarget();
        }
    }

    private void PickRandomTarget()
    {
        Bounds bounds = gridArea.bounds;

        int x = Mathf.RoundToInt(Random.Range(bounds.min.x, bounds.max.x));
        int y = Mathf.RoundToInt(Random.Range(bounds.min.y, bounds.max.y));

        targetPosition = new Vector2(x, y);
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        int x = Mathf.RoundToInt(Random.Range(bounds.min.x, bounds.max.x));
        int y = Mathf.RoundToInt(Random.Range(bounds.min.y, bounds.max.y));

        while (snake.Occupies(x, y))
        {
            x++;
        }

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Snake>() != null)
        {
            RandomizePosition();
        }
    }
}
