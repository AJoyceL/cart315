using UnityEngine;

public class ExitDoorReset : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            CharacterController controller = player.GetComponent<CharacterController>();

            if (controller != null) 
            {
                controller.enabled = false;
            }

            player.position = spawnPoint.position;

            if (controller != null)
            {
               controller.enabled = true;
            }
        }
    }
}