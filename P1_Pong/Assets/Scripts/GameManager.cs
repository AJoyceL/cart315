using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Score score;
    public Ball ball;
    public Balls balls;
    public GameStates gameState;

    private void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        ball.ResetBall();
        ball.AddStartingForce();

        balls.ResetBalls();
        balls.AddStartingForce();
    }

    public void CourtTriggered(int courtId)
    {
        score.DecreaseScore((courtId == 0 ? 1 : 0));
        StartRound();
    }
}   