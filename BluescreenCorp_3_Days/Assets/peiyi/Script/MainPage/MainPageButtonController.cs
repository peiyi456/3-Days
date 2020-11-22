using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPageButtonController : MonoBehaviour
{
    public GameObject settingPanel;
    public Image FadeInFadeOut;

    private void Start()
    {
        settingPanel.SetActive(false);
    }

    public void OnClickPlay()
    {
        StartCoroutine(changeScene());
    }

    public void OnClickSetting()
    {
        settingPanel.SetActive(true); 
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    
}
