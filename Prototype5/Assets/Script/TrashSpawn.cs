
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject trashPrefab;
    public int trashAmount;

    // Position
    public Vector2 minPos;
    public Vector2 maxPos;

    // Overlap
    public LayerMask ObstacleLayer;
    public Vector2 checkSize = new Vector2(.5f, .5f); //Check spawn area size

    void Start()
    {
        trashAmount = Random.Range(3, 7);

        for (int i = 0; i < trashAmount; i++)
        {
            bool validPosition = false;

            for (int attempt = 0; attempt < 100; attempt++)
            {
                int x = Random.Range(
                    Mathf.CeilToInt(minPos.x),
                    Mathf.FloorToInt(maxPos.x) + 1
                );

                int y = Random.Range(
                    Mathf.CeilToInt(minPos.y),
                    Mathf.FloorToInt(maxPos.y) + 1
                );

                Vector2 randomPos = new Vector2(x, y);

                Collider2D Obstacle = Physics2D.OverlapBox(
                    randomPos,
                    checkSize,
                    0f,
                    ObstacleLayer
                );

                if (Obstacle == null)
                {
                    Instantiate(trashPrefab, randomPos, Quaternion.identity);
                    validPosition = true;
                    break;
                }
            }

            if (!validPosition)
            {
                Debug.Log("Could not find an empty position for trash.");
            }
        }
    }
}
