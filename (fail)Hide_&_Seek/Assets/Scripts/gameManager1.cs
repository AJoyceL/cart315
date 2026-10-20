using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public void ResetScene()
    {
        Debug.Log("Restarting scene!");

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}