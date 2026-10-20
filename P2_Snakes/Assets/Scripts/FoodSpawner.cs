
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public int foodCount = 5;

    private void Start()
    {
        for (int i = 0; i < foodCount; i++)
        {
            Instantiate(foodPrefab);
        }
    }
}
