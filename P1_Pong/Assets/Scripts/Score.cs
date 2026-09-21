using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int scorePlayerOne;
    public int scorePlayerTwo;

    public TextMeshProUGUI scorePlayerOneText;
    public TextMeshProUGUI scorePlayerTwoText;

    private void Start()
    {
        ResetScore();
        UpdateScore();
    }

    public void DecreaseScore(int playerId)
    {
        switch (playerId)
        {
            case 0:
                scorePlayerOne = scorePlayerTwo--;
                break;
            case 1:
                scorePlayerTwo = scorePlayerOne--;
                break;
        }
        
        UpdateScore();
    }

    public void ResetScore()
    {
        scorePlayerOne = 10;
        scorePlayerTwo = 10;
    }

    // Update is called once per frame
    void UpdateScore()
    {
        scorePlayerOneText.text = scorePlayerOne.ToString();
        scorePlayerTwoText.text = scorePlayerTwo.ToString();
    }
}