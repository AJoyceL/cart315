
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    public void ReStartGame()
    {
        
    }

    public void Reload()
    {
        Debug.Log("Button called");
        SceneManager.LoadScene("StartScene");
    }
}
