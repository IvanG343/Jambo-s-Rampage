using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   private void StartScene(int id)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(id);
    }

    public void StartFirstLevel()
    {
        StartScene(1);
    }

    public void RestartLevel()
    {
        StartScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitLevel()
    {
        StartScene(0);
    }
}
