using UnityEngine;
using UnityEngine.InputSystem;

public class paddle : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public Vector2 direction;

    public float speed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = Vector2.zero; //resets the direction to zero so that the paddle doesn't move when no key is pressed
        if(Keyboard.current.wKey.isPressed) //if the w key is pressed, the paddle will move up
        {
            direction += Vector2.up;
        }
        if(Keyboard.current.sKey.isPressed) //if the s key is pressed, the paddle will move down
        {
            direction += Vector2.down;
        }
    }

    private void FixedUpdate()
    {
       if(direction.sqrMagnitude == 0) return;

       _rigidBody.AddForce(direction * speed);
    }
}
