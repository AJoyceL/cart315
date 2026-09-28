using UnityEngine;

public class CPUController : MonoBehaviour
{
    public Ball ball;
    public Balls balls;
    public Paddle paddle;

    private bool followBalls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        followBalls = Random.value < 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ballPos = ball.transform.position;
        Vector2 ballsPos = balls.transform.position;
        Vector2 paddlePos = paddle.transform.position;

        float targetY = followBalls ? ballsPos.y : ballPos.y;
        paddle.direction = new Vector2(0.0f, targetY - paddlePos.y);
    }
}