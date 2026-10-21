
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake2 : MonoBehaviour
{
    public Transform segmentPrefab;
    public Vector2Int direction = Vector2Int.right;
    public float speed = 10f;
    public float speedMultiplier = 1f;
    public int initialSize = 4;
    public bool moveThroughWalls = false;
    private float startTime;

    private readonly List<Transform> segments = new List<Transform>();
    private Vector2Int input;
    private float nextUpdate;

    private void Start()
    {
        ResetState();
        startTime = Time.time + 1f;
    }

    private void Update()
    {
        // Only allow turning up or down while moving horizontally
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
        if (Time.time < startTime)
        {
            return;
        }

        if (Time.time < nextUpdate)
            return;

        if (input != Vector2Int.zero)
            direction = input;

        // Move the body segments
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        // Move the head
        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);

        nextUpdate = Time.time + (1f / (speed * speedMultiplier));
    }

    //loads win scene
    private void LoadWinScene()
    {
        SceneManager.LoadScene("WinPurple");
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);

        if (segments.Count >= 15)
        {
            LoadWinScene();
        }
    }

    public void Shrink()
    {
        if (segments.Count <= 1)
            return;

        Transform lastSegment = segments[segments.Count - 1];
        segments.RemoveAt(segments.Count - 1);
        Destroy(lastSegment.gameObject);
    }

    public void ResetState()
    {
        direction = Vector2Int.right;
        input = Vector2Int.zero;

        // Start Player 2 at a different position
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
                return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Player 2 collided with: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("Food"))
        {
            Food food = other.GetComponent<Food>();

            if (food != null)
                food.Eat(null, this);
        }
        else if (other.CompareTag("Wall"))
        {
            if (moveThroughWalls)
                Traverse(other.transform);
            else
                ResetState();
        }
        else if (other.CompareTag("Player") || other.CompareTag("Obstacle"))
        {
            ResetState();
        }
    }

    private void Traverse(Transform wall)
    {
        Vector3 position = transform.position;

        if (direction.x != 0)
            position.x = Mathf.RoundToInt(-wall.position.x + direction.x);
        else if (direction.y != 0)
            position.y = Mathf.RoundToInt(-wall.position.y + direction.y);

        transform.position = position;
    }
}
