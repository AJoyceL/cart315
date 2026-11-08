using UnityEngine;

public class MonsterRotate : MonoBehaviour
{
    public Transform monster;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            monster.localRotation = Quaternion.Euler(-45f, 0f, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            monster.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}