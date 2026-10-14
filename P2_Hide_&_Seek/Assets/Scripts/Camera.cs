using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target; 
    public Vector3 offset; 
   
    void Start()
    {
        
    }

    void Update()
    {
        // Check if the target is assigned
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                5f * Time.deltaTime
            );
        }
    }
}
