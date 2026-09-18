using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int scoreP1 = 0; // variable for player 1 score
    public int scoreP2 = 0; // variable for player 2 score


    public void UpdateScore(int playerId)
    {
        switch (playerId)
        {
            case 0: scoreP1--; 
            break;
            case 1: scoreP2--; 
            break;
        }
        // if (playerId == 0)
        // {
            
        // }
    }
}
