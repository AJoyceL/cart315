
using UnityEngine;
using UnityEngine.Tilemaps;

public class Trash : MonoBehaviour
{
    public GameObject trashPrefab; //trash prefab
    public Tilemap groundTilemap; //ground tilemap

    public int trashAmount;

    void Start()
    {
        trashAmount = Random.Range(3, 7); //range of trash amount

        BoundsInt bounds = groundTilemap.cellBounds;

        for (int i = 0; i < trashAmount; i++)
        {
            for (int attempt = 0; attempt < 100; attempt++)
            {
                int x = Random.Range(bounds.xMin, bounds.xMax);
                int y = Random.Range(bounds.yMin, bounds.yMax);

                Vector3Int cellPosition = new Vector3Int(x, y, 0);

                if (groundTilemap.HasTile(cellPosition))
                {
                    Vector3 spawnPosition = groundTilemap.GetCellCenterWorld(cellPosition);

                    Instantiate(trashPrefab, spawnPosition, Quaternion.identity);

                    break;
                }
            }
        }
    }
}
