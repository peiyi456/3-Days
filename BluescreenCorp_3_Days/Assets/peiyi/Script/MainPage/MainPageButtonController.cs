using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainPageButtonController : MonoBehaviour
{
    public static bool isBackMenu;

    public GameObject settingPanel;
    public Image FadeIn;
    public Image FadeOut;

    private void Start()
    {
        Time.timeScale = 1;
        settingPanel.SetActive(false);
        //StartCoroutine(DoFade());
        if(isBackMenu)
        {
            StartCoroutine(DoFade());
        }
    }

    public void OnClickPlay()
    {
        //StartCoroutine(changeScene());
        LoadingPageScripts.loadSceneNumber = 1;
        StartCoroutine(DoFade());

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
        LoadingPageScripts.loadSceneNumber = 1;
        yield return new WaitForSeconds(2);
        //SceneManager.LoadScene(2);
    }

    IEnumerator DoFade()
    {
        if (isBackMenu)
        {
            FadeOut.gameObject.SetActive(true);
            var sequence = DOTween.Sequence();
            sequence.Append(FadeOut.DOFade(0f, 2f));
            yield return new WaitForSeconds(2f);
            FadeOut.gameObject.SetActive(false);
            isBackMenu = false;
        }

        else
        {
            FadeIn.gameObject.SetActive(true);
            var sequence = DOTween.Sequence();
            sequence.Append(FadeIn.DOFade(1f, 2f));
            yield return new WaitForSeconds(2f);
            //FadeIn.gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
    }

    public void OnClickCreditButton()
    {
        LoadingPageScripts.loadSceneNumber = 5;
        StartCoroutine(PlayFadeIn());
    }

    IEnumerator PlayFadeIn()
    {
        FadeIn.gameObject.SetActive(true);
        var sequence = DOTween.Sequence();
        sequence.Append(FadeIn.DOFade(1f, 2f));
        yield return new WaitForSeconds(2f);
        //FadeIn.gameObject.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
