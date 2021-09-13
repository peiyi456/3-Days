using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class WinPageAnimation : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image badgeImage;
    [SerializeField] Sprite bronze;
    [SerializeField] Sprite silver;
    [SerializeField] Sprite gold;

    [SerializeField] TextMeshProUGUI[] ObjectivesTextOfTheMap;
    [SerializeField] TextMeshProUGUI[] ObjectivesTextOfTheWinPage;

    [SerializeField] float colorSpeed;
    [SerializeField] float scaleSpeed;
    [SerializeField] int objectivesDone = 0;
    [SerializeField] bool isCount = false;
    [SerializeField] bool isPlay = false;

    int number;
    int number2;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ObjectivesTextOfTheMap.Length; i++)
        {
            ObjectivesTextOfTheWinPage[i].text = ObjectivesTextOfTheMap[i].text;
        }

        //PlayerPrefs.SetInt("UNLOCK_MAP", 1);
        number = PlayerPrefs.GetInt("BADGE_UNLOCK_MAP1");
        number2 = PlayerPrefs.GetInt("BADGE_UNLOCK_MAP2");
        //PlayerPrefs.SetInt("BADGE_UNLOCK_MAP2", 0);
        //PlayerPrefs.SetInt("BADGE_UNLOCK_MAP1", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (MapChoosing.chooseMapNo == 1)
        {
            if (objectivesDone > 1)
            {
                PlayerPrefs.SetInt("UNLOCK_MAP", 1);
            }

            if (objectivesDone > number)
            {
                PlayerPrefs.SetInt("BADGE_UNLOCK_MAP1", objectivesDone);
                Debug.Log("123");
            }
        }

        else if(MapChoosing.chooseMapNo == 2)
        {
            if (objectivesDone > number2)
            {
                PlayerPrefs.SetInt("BADGE_UNLOCK_MAP2", objectivesDone);
            }
        }
    }

    public void PlayObjectiveDoneAnimation_1()
    {
        if (GameManager.instance.Objective1 == true)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(ObjectivesTextOfTheWinPage[0].DOColor(Color.yellow, colorSpeed));
            objectivesDone++;

        }
    }

    public void PlayObjectiveDoneAnimation_2()
    {
        if (GameManager.instance.Objective2 == true)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(ObjectivesTextOfTheWinPage[1].DOColor(Color.yellow, colorSpeed));
            objectivesDone++;
        }
    }

    public void PlayObjectiveDoneAnimation_3()
    {
        if (GameManager.instance.Objective3 == true)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(ObjectivesTextOfTheWinPage[2].DOColor(Color.yellow, colorSpeed));
            objectivesDone++;
        }
    }

    public void PlayBadgeAnimation()
    {
        if(objectivesDone == 1)
        {
            badgeImage.sprite = bronze;
            var sequence = DOTween.Sequence();
            sequence.Append(badgeImage.rectTransform.DOScale(new Vector3(3, 3, 1), scaleSpeed * 0.5f));
            sequence.Append(badgeImage.rectTransform.DOScale(new Vector3(1, 1, 1), scaleSpeed * 0.5f));
            //objectivesDone++;
        }

        else if (objectivesDone == 2)
        {
            badgeImage.sprite = silver;
            var sequence = DOTween.Sequence();
            sequence.Append(badgeImage.rectTransform.DOScale(new Vector3(3, 3, 1), scaleSpeed * 0.5f));
            sequence.Append(badgeImage.rectTransform.DOScale(new Vector3(1, 1, 1), scaleSpeed * 0.5f));
            //objectivesDone++;
        }

        else if(objectivesDone == 3)
        {
            badgeImage.sprite = gold;
            var sequence = DOTween.Sequence();
            sequence.Append(badgeImage.rectTransform.DOScale(new Vector3(3, 3, 1), scaleSpeed * 0.5f));
            sequence.Append(badgeImage.rectTransform.DOScale(new Vector3(1, 1, 1), scaleSpeed * 0.5f));
           // objectivesDone++;
        }
    }

    public void PlayButtonAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(button.transform.DOScale(new Vector3(2, 2, 1), scaleSpeed * 0.5f));
        sequence.Append(button.transform.DOScale(new Vector3(1, 1, 1), scaleSpeed * 0.5f));
    }
}
