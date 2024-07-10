using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public GameObject exitPanel;

    public float clickDelay = 0.1f;

    public void OnBtnClick(string corName)
    {
        StartCoroutine(corName);
    }

    private IEnumerator OnNewGameBtnClick()
    {
        yield return new WaitForSeconds(clickDelay);
        //Load first level scene
    }

    private IEnumerator OnSettingsBtnClick()
    {
        yield return new WaitForSeconds(clickDelay);
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private IEnumerator OnSettingsBackBtnClick()
    {
        yield return new WaitForSeconds(clickDelay);
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    private IEnumerator OnSettingsSaveBtnClick()
    {
        yield return new WaitForSeconds(clickDelay);
        //Save settings
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    private IEnumerator OnExitBtnClick()
    {
        yield return new WaitForSeconds(clickDelay);
        menuPanel.SetActive(false);
        exitPanel.SetActive(true);
    }

    private IEnumerator OnConfirmExitBtnClick()
    {
        yield return new WaitForSeconds(clickDelay);
        Application.Quit();
    }

    private IEnumerator OnDeclineExitBtnClick()
    {
        yield return new WaitForSeconds(clickDelay);
        exitPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
