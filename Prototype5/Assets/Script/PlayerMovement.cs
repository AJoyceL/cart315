using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction;
    private Rigidbody2D _rigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = Vector2.zero;

        //Movement on Y Axis
        if (Keyboard.current.wKey.isPressed)
        {
            direction.y = 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            direction.y = -1;
        }

        //Movement on X Axis
        if (Keyboard.current.dKey.isPressed)
        {
            direction.x = 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            direction.x = -1;
        }

        direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = direction * speed;
    }
}
