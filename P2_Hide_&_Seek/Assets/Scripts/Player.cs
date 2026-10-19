
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direction;
    private bool canMove = true;

    public float speed = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPlayer();
    }
    

    public void ResetPlayer()
    {
        Debug.Log("ResetPlayer called!");

        direction = 0f;
        rb.linearVelocity = Vector2.zero;
        rb.position = new Vector2(-21f, rb.position.y);
        transform.position = new Vector3(-21f, transform.position.y, transform.position.z);
    }



    public void SetMovementEnabled(bool enabled)
    {
        canMove = enabled;

        if (!canMove)
        {
            direction = 0f;
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void Update()
    {
        direction = 0f;

        if (!canMove)
            return;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction = 1f;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            canMove ? direction * speed : 0f,
            rb.linearVelocity.y
        );
    }
}

