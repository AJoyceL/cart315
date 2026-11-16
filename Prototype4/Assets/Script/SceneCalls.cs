using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCalls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartGame()
    {
        
    }

    // Update is called once per frame
    public void ReLoad()
    {
        SceneManager.LoadScene("Liminal");
    }
}
