using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MapChoosing : MonoBehaviour
{
    public static int chooseMapNo;
    [SerializeField] Image testing;
    public static bool fadeOut;
    float original;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut = false;
        original = testing.color.a;
        StartCoroutine(DoFade());
        //sceneName = loadingPage.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoFade()
    {
        if (fadeOut == false)
        {
            testing.gameObject.SetActive(true);
            var sequence = DOTween.Sequence();
            sequence.Append(testing.DOFade(0f, 2f));
            yield return new WaitForSeconds(1.5f);
            testing.gameObject.SetActive(false);
            fadeOut = true;
        }

        else if(fadeOut == true)
        {
            testing.gameObject.SetActive(true);
            var sequence = DOTween.Sequence();
            sequence.Append(testing.DOFade(1f, 2f));
            Debug.Log("Hallo");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(2);

        }
    }

    public void SelectedMap(int sceneChg)
    {
        chooseMapNo = sceneChg;
        LoadingPageScripts.loadSceneNumber = sceneChg + 2;
        StartCoroutine(DoFade());
    }

    public void PlayerChooseMap()
    {
        if (this.GetComponent<Button>().interactable == true)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(this.GetComponent<Image>().rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.5f));
            this.transform.GetChild(0).gameObject.SetActive(true);
            //sequence.Append(image.rectTransform.DOScale(new Vector3(1, 1, 1), scaleSpeed));
        }
    }

    public void OnExitChooseMap()
    {
        if (this.GetComponent<Button>().interactable == true)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(this.GetComponent<Image>().rectTransform.DOScale(new Vector3(1, 1, 1), 0.5f));
            this.transform.GetChild(0).gameObject.SetActive(false);
            //sequence.Append(image.rectTransform.DOScale(new Vector3(1, 1, 1), scaleSpeed));
        }
    }

    //public void ShowToolTips()
    //{
    //    if(this.GetComponent<Button>)
    //    this.transform.GetChild(0).gameObject.SetActive(true);
    //}
}
