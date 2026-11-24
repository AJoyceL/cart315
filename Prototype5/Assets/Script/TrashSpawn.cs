using UnityEngine;

public class Trash : MonoBehaviour
{ public GameObject trashPrefab;
    public int trashAmount;

    public Vector2 minPos;
    public Vector2 maxPos;

    void Start()
    {
        Debug.Log("Min Position: " + minPos);
        Debug.Log("Max Position: " + maxPos);

        trashAmount = Random.Range(3, 7);

        for (int i = 0; i < trashAmount; i++)
        {
            float positionX = Random.Range(minPos.x, maxPos.x);
            float positionY = Random.Range(minPos.y, maxPos.y);

            Vector2 randomPos = new Vector2(positionX, positionY);
            
            Debug.Log(randomPos);

            Instantiate(trashPrefab, randomPos, Quaternion.identity);
        }
    }
}
