
// using UnityEngine;

// [RequireComponent(typeof(BoxCollider2D))]
// public class Food : MonoBehaviour
// {
//     public Collider2D gridArea;
//     public float moveSpeed = 0.5f;

//     private Snake snake;
//     private Vector2 targetPosition;

//     private void Awake()
//     {
//         snake = FindFirstObjectByType<Snake>();
//     }

//     private void Start()
//     {
//         RandomizePosition();
//         PickRandomTarget();
//     }

//     private void Update()
//     {
//         // Move slowly toward the target
//         transform.position = Vector2.MoveTowards(
//             transform.position,
//             targetPosition,
//             moveSpeed * Time.deltaTime
//         );

//         // Pick a new target when reached
//         if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
//         {
//             PickRandomTarget();
//         }
//     }

//     private void PickRandomTarget()
//     {
//         Bounds bounds = gridArea.bounds;

//         int x = Mathf.RoundToInt(Random.Range(bounds.min.x, bounds.max.x));
//         int y = Mathf.RoundToInt(Random.Range(bounds.min.y, bounds.max.y));

//         targetPosition = new Vector2(x, y);
//     }


//     public void RandomizePosition()
//     {
//         Bounds bounds = gridArea.bounds;

//         int minX = Mathf.CeilToInt(bounds.min.x);
//         int maxX = Mathf.FloorToInt(bounds.max.x);
//         int minY = Mathf.CeilToInt(bounds.min.y);
//         int maxY = Mathf.FloorToInt(bounds.max.y);

//         for (int i = 0; i < 100; i++)
//         {
//             int x = Random.Range(minX, maxX + 1);
//             int y = Random.Range(minY, maxY + 1);

//             if (!snake.Occupies(x, y))
//             {
//                 transform.position = new Vector2(x, y);
//                 return;
//             }
//         }

//         Debug.LogWarning("Could not find a free position for food.");
//     }

//     // private void OnTriggerEnter2D(Collider2D other)
//     // {
//     //     if (other.CompareTag("Snake"))
//     //     {
//     //         RandomizePosition();
//     //     }
//     // }

// }

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
                return;
            }
        }

        Debug.LogWarning("No free position found for food.");
    }
}
