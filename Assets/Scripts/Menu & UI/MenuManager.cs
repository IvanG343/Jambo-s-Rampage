using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public GameObject exitPanel;
    public GameObject winPanel;
    public GameObject loosePanel;

    public GameObject pausePanel;

    public float clickDelay = 0.1f;

    public bool isPaused;

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private AudioClip clickSound;

    public void OnBtnClick(string corName)
    {
        StartCoroutine(corName);
        SoundManager.instance.PlaySound(clickSound);
    }

    private IEnumerator OnNewGameBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        sceneLoader.StartFirstLevel();
    }

    private IEnumerator OnSettingsBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private IEnumerator OnSettingsBackBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    private IEnumerator OnExitBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        menuPanel.SetActive(false);
        exitPanel.SetActive(true);
    }

    private IEnumerator OnConfirmExitBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        Application.Quit();
    }

    private IEnumerator OnDeclineExitBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        exitPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    private IEnumerator OnRestartBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        sceneLoader.RestartLevel();
    }
    private IEnumerator OnContBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        OnPauseBtnClick();
    }

    private IEnumerator OnExitLevelBtnClick()
    {
        yield return new WaitForSecondsRealtime(clickDelay);
        sceneLoader.ExitLevel();
    }

    public void OnPauseBtnClick()
    {
        if (!pausePanel.activeSelf)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            isPaused = false;
        }
    }
}
