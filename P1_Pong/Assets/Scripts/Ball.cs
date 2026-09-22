using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 100.0f;
    
    //transparency variables
    public float alpha = 1f;
    public float fadeSpeed = 10.0f;
    private float duration = 5.0f;
    SpriteRenderer ballSprite;
    Color ballColor;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        
        //Calls the ball spirerender + colour
        ballSprite = GetComponent<SpriteRenderer>();
        ballColor = Color.white;
    }

    private void Update()
    {
        ballSprite.color = Color.Lerp(ballSprite.color, ballColor, fadeSpeed * Time.deltaTime);
    }

    public void ResetBall()
    {
        _rigidBody.linearVelocity = Vector2.zero;
        _rigidBody.angularVelocity = 0;
        transform.position = Vector3.zero;
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = (Random.value < 0.5f ? -1.0f : 1.0f) * Random.Range(0.5f, 0.9f);

        Vector2 direction = new Vector2(x, y);

        _rigidBody.AddForce(direction * speed);
    }
    
    //triggers transparency when ball collides with paddle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Paddle>() != null)
        {
            ballColor = new Color(1, 1, 1, 0);
            Invoke(nameof(MakeVisible), duration);
        }
    }

    //calls back the ball to visible
    private void MakeVisible()
    {
        ballColor = new Color(1, 1, 1, alpha);
    }
}