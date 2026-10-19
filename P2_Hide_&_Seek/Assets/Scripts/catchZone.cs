using UnityEngine;

public class catchZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Inside catch zone: " + other.name);

        Player playerScript = other.GetComponentInParent<Player>();

        if (playerScript == null)
        {
            Debug.Log("No Player script found.");
            return;
        }

        Nightmare nightmare = GetComponentInParent<Nightmare>();

        if (nightmare == null)
        {
            Debug.Log("No Nightmare script found.");
            return;
        }

        bool canSee = nightmare.CanSeePlayer();
        Debug.Log("Can see player: " + canSee);

        if (canSee)
        {
            Debug.Log("Calling ResetPlayer!");
            playerScript.ResetPlayer();
        }
    }
}
