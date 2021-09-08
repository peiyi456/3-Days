using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MapChoosing : MonoBehaviour
{
    //[SerializeField] Button left;
    //[SerializeField] Button right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedMap(int sceneChg)
    {
        SceneManager.LoadScene(sceneChg);
    }

    public void PlayerChooseMap()
    {
        if (this.GetComponent<Button>().interactable == true)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(this.GetComponent<Image>().rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.5f));
            //sequence.Append(image.rectTransform.DOScale(new Vector3(1, 1, 1), scaleSpeed));
        }
    }

    public void OnExitChooseMap()
    {
        if (this.GetComponent<Button>().interactable == true)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(this.GetComponent<Image>().rectTransform.DOScale(new Vector3(1, 1, 1), 0.5f));
            //sequence.Append(image.rectTransform.DOScale(new Vector3(1, 1, 1), scaleSpeed));
        }
    }
}
