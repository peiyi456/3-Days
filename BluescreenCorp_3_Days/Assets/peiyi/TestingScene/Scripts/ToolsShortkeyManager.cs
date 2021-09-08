using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolsShortkeyManager : MonoBehaviour
{
    [SerializeField] List<Image> toolsKeyImage;
    [SerializeField] Item[] items;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            toolsKeyImage.Add(this.transform.GetChild(i).GetChild(0).GetComponentInChildren<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.hasCampsite)
        {
            toolsKeyImage[0].color = Color.white;
        }

        else
        {
            toolsKeyImage[0].color = Color.black;
        }

        if (GameManager.instance.hasTorch)
        {
            toolsKeyImage[1].color = Color.white;
        }

        else
        {
            toolsKeyImage[1].color = Color.black;
        }

        if (GameManager.instance.hasFishingRod)
        {
            toolsKeyImage[2].color = Color.white;
        }

        else
        {
            toolsKeyImage[2].color = Color.black;
        }

        if (GameManager.instance.hasAxe)
        {
            toolsKeyImage[3].color = Color.white;
        }

        else
        {
            toolsKeyImage[3].color = Color.black;
        }

        if (GameManager.instance.hasKnife)
        {
            toolsKeyImage[4].color = Color.white;
        }

        else
        {
            toolsKeyImage[4].color = Color.black;
        }

        if (GameManager.instance.hasLance)
        {
            toolsKeyImage[5].color = Color.white;
        }

        else
        {
            toolsKeyImage[5].color = Color.black;
        }
    }

    public void ShowToolTips(Button button)
    {
        if(button.transform.GetChild(0).GetComponent<Image>().color == Color.white)
        {
            GameObject toolTips = button.transform.GetChild(1).gameObject;
            toolTips.SetActive(true);
        }
    }

    public void HideToolTip(Button button)
    {
        GameObject toolTips = button.transform.GetChild(1).gameObject;
        toolTips.SetActive(false);
    }
}
