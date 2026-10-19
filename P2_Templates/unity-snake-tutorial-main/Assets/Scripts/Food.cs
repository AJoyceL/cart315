using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    private float moveSpeed;

    private Snake snake;
    private Vector2 targetPosition;

    private void Awake()
    {
        snake = FindFirstObjectByType<Snake>();
    }

    private void Start()
    {
        moveSpeed = Random.Range(0.2f, 5f);

        RandomizePosition();
        PickRandomTarget();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            PickRandomTarget();
        }
    }

    private void PickRandomTarget()
    {
        Bounds bounds = gridArea.bounds;

        targetPosition = new Vector2(
            Random.Range(
                Mathf.CeilToInt(bounds.min.x),
                Mathf.FloorToInt(bounds.max.x) + 1
            ),
            Random.Range(
                Mathf.CeilToInt(bounds.min.y),
                Mathf.FloorToInt(bounds.max.y) + 1
            )
        );
    }

    
    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        moveSpeed = Random.Range(0.2f, 5f);

        for (int i = 0; i < 100; i++)
        {
            int x = Random.Range(
                Mathf.CeilToInt(bounds.min.x),
                Mathf.FloorToInt(bounds.max.x) + 1
            );

            int y = Random.Range(
                Mathf.CeilToInt(bounds.min.y),
                Mathf.FloorToInt(bounds.max.y) + 1
            );

            if (!snake.Occupies(x, y))
            {
                transform.position = new Vector2(x, y);
                targetPosition = transform.position;
                PickRandomTarget();
                return;
            }
        }

        // Debug.LogWarning("No free position found for food.");
    }

}
