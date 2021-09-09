using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingEffect : MonoBehaviour
{
    [SerializeField] AudioClip WinSound;
    [SerializeField] Image FadeIn;
    [SerializeField] GameObject WinPage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayFadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayFadeIn()
    {
        SoundManager.instance.soundEffect.PlayOneShot(WinSound);
        yield return new WaitForSeconds(0.3f);
        FadeIn.gameObject.SetActive(true);
        var sequence = DOTween.Sequence();
        sequence.Append(FadeIn.DOFade(1f, 2f));
        yield return new WaitForSeconds(2f);
        //FadeIn.gameObject.SetActive(false);
        WinPage.SetActive(true);
        //SceneManager.LoadScene(2);
    }
}
