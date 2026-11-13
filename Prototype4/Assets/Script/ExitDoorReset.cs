using UnityEngine;

public class ExitDoorReset : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            transform.position = spawnPoint.position;
        }
    }
}
