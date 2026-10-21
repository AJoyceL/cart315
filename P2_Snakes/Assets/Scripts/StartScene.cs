
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartGame()
    {
        
    }

    public void LoadGame()
    {
        Debug.Log("Button called");
        SceneManager.LoadScene("Snake");
    }
}
