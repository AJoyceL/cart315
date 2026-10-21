
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    private float moveSpeed;

    private Snake snake;
    private Snake2 snake2;
    private Vector2 targetPosition;
    private int foodEffect;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        snake = FindFirstObjectByType<Snake>();
        snake2 = FindFirstObjectByType<Snake2>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveSpeed = Random.Range(0.2f, 5f);

        RandomiseEffect();
        RandomisePosition();
        PickRandomTarget();
    }

    private void Update()
    {
        if (rb == null) return;

        moveDirection = (targetPosition - rb.position).normalized;

        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            PickRandomTarget();
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        rb.MovePosition(
            rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Wall"))
        {
            ContactPoint2D contact = collision.GetContact(0);

            moveDirection = Vector2.Reflect(
                moveDirection,
                contact.normal
            ).normalized;

            targetPosition = rb.position + moveDirection * 5f;
        }
    }

    private void PickRandomTarget()
    {
        if (gridArea == null) return;

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

    private void RandomiseEffect()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
            foodEffect = 1;
        else if (random == 1)
            foodEffect = 2;
        else
            foodEffect = -1;

        Debug.Log("New food effect: " + foodEffect + " segment(s)");
    }

    public void Eat(Snake eatingSnake, Snake2 eatingSnake2)
    {
        if (foodEffect == 1)
        {
            if (eatingSnake != null)
                eatingSnake.Grow();
            else if (eatingSnake2 != null)
                eatingSnake2.Grow();

            Debug.Log("GOOD FOOD: Grew by 1 segment!");
        }
        else if (foodEffect == 2)
        {
            if (eatingSnake != null)
            {
                eatingSnake.Grow();
                eatingSnake.Grow();
            }
            else if (eatingSnake2 != null)
            {
                eatingSnake2.Grow();
                eatingSnake2.Grow();
            }

            Debug.Log("GOOD FOOD: Grew by 2 segments!");
        }
        else if (foodEffect == -1)
        {
            if (eatingSnake != null)
                eatingSnake.Shrink();
            else if (eatingSnake2 != null)
                eatingSnake2.Shrink();

            Debug.Log("BAD FOOD: Lost 1 segment!");
        }

        RandomisePosition();
    }

    public void RandomisePosition()
    {
        if (gridArea == null)
        {
            Debug.LogError("Food is missing its Grid Area!");
            return;
        }

        Bounds bounds = gridArea.bounds;

        moveSpeed = Random.Range(0.2f, 5f);
        RandomiseEffect();

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

            bool occupiedByPlayer =
                snake != null && snake.Occupies(x, y);

            bool occupiedByPlayer2 =
                snake2 != null && snake2.Occupies(x, y);

            if (!occupiedByPlayer && !occupiedByPlayer2)
            {
                transform.position = new Vector2(x, y);

                if (rb != null)
                    rb.position = new Vector2(x, y);

                targetPosition = transform.position;
                PickRandomTarget();
                return;
            }
        }

        Debug.LogWarning("No free position found for food.");
    }
}
