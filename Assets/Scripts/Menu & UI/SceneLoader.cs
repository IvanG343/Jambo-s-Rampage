using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public void FadeToLevel(int levelIndex)
    {
        Time.timeScale = 1.0f;
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        MusicController.instance.StopMusic();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void StartFirstLevel()
    {
        FadeToLevel(1);
    }

    public void RestartLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitLevel()
    {
        FadeToLevel(0);
    }
}
