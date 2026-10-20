
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AISnake : MonoBehaviour
{
    public Transform segmentPrefab;
    public Vector2Int direction = Vector2Int.right;
    public float speed = 10f;
    public float speedMultiplier = 1f;
    public int initialSize = 4;
    public bool moveThroughWalls = false;

    private readonly List<Transform> segments = new List<Transform>();
    private Vector2Int input;
    private float nextUpdate;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        // Comment in for AISnake. Comment out for 2nd player
        //FindFood();
        // Comment in for 2nd player. Comment out for AISnake
        // Only allow turning up or down while moving in the x-axis
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                input = Vector2Int.up;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                input = Vector2Int.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                input = Vector2Int.right;
            } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                input = Vector2Int.left;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Time.time < nextUpdate)
        {
            return;
        }

        if (input != Vector2Int.zero)
        {
            direction = input;
        }

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);

        nextUpdate = Time.time + (1f / (speed * speedMultiplier));
    }

    
private void FindFood()
{
    GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

    GameObject closestFood = null;
    float closestDistance = Mathf.Infinity;

    foreach (GameObject food in foods)
    {
        float distance = Vector2.Distance(
            transform.position,
            food.transform.position
        );

        if (distance < closestDistance)
        {
            closestDistance = distance;
            closestFood = food;
        }
    }

    Vector2 difference = Vector2.zero;

    if (closestFood != null)
    {
        difference = closestFood.transform.position - transform.position;
    }

    // Choose the direction that moves closer to the food first.
    Vector2Int preferredDirection = direction;

    if (closestFood != null)
        {
            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
            {
                preferredDirection = difference.x > 0
                    ? Vector2Int.right : Vector2Int.left;
            }
            else if (Mathf.Abs(difference.y) > 0.1f)
            {
                preferredDirection = difference.y > 0
                    ? Vector2Int.up : Vector2Int.down;
            }
        }

        // Try the preferred direction first, then the other directions.
        Vector2Int[] options =
        {
            preferredDirection,
            new Vector2Int(-preferredDirection.y, preferredDirection.x),
            new Vector2Int(preferredDirection.y, -preferredDirection.x),
            -direction
        };

        foreach (Vector2Int option in options)
        {
            // Never turn directly backward.
            if (option == -direction)
            {
                continue;
            }

            int nextX = Mathf.RoundToInt(transform.position.x) + option.x;
            int nextY = Mathf.RoundToInt(transform.position.y) + option.y;

            bool hitsBody = false;

            // Check the body, excluding the head and the last segment,
            // which moves away on the next step.
            for (int i = 1; i < segments.Count - 1; i++)
            {
                if (Mathf.RoundToInt(segments[i].position.x) == nextX &&
                    Mathf.RoundToInt(segments[i].position.y) == nextY)
                {
                    hitsBody = true;
                    break;
                }
            }

            if (!hitsBody)
            {
                input = option;
                return;
            }
        }

        // If no safe turn is available, keep moving forward.
        input = direction;
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void ResetState()
    {
        direction = Vector2Int.right;
        input = Vector2Int.zero;
        transform.position = new Vector3(5, 0, 0);

        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);

        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }
    }

    public bool Occupies(int x, int y)
    {
        foreach (Transform segment in segments)
        {
            if (Mathf.RoundToInt(segment.position.x) == x &&
                Mathf.RoundToInt(segment.position.y) == y)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();

            Food food = other.GetComponent<Food>();

            if (food != null)
            {
                food.RandomizePosition();
            }
        }
        else if (other.CompareTag("Wall"))
        {
            if (moveThroughWalls)
            {
                Traverse(other.transform);
            }
            else
            {
                ResetState();
            }
        }
        else if (other.CompareTag("Player") || (other.CompareTag("Obstacle")))
        {
            ResetState();
        }
    }

    private void Traverse(Transform wall)
    {
        Vector3 position = transform.position;

        if (direction.x != 0)
        {
            position.x = Mathf.RoundToInt(-wall.position.x + direction.x);
        }
        else if (direction.y != 0)
        {
            position.y = Mathf.RoundToInt(-wall.position.y + direction.y);
        }

        transform.position = position;
    }
}
