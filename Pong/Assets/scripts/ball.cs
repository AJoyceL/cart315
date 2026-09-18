using UnityEngine;

public class ball : MonoBehaviour
{
    // variable for rigidbody
    private Rigidbody2D _rigidBody;

    public float speed = 200f; // variable for speed of the ball

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        float x = 1f;
        float y = 0f;

        if(Random.value < 0.5f) 
        {
            x = -1f; //randomly chooses a direction for the ball to move in
            y = -1f;
        }
        else 
        {
            x = 1f;
            y = 1f;
        }

        y = y * Random.Range(.5f, .9f);
        

        Vector2 direction = new Vector2(x, y); //calls vector2 to create a direction for the ball to move in
        _rigidBody.AddForce(direction * speed); //this adds force to the ball
    }


}
