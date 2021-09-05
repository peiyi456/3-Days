using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookingButtonFunction : MonoBehaviour
{
    [SerializeField] Button buttons;
    [SerializeField] Item cookItem;

    [SerializeField] Item cookResult;

    [SerializeField] Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = CampFireInteract.instace.ProgressBar.GetComponentInChildren<Slider>();
        buttons.transform.GetChild(0).GetComponent<Image>().sprite = cookResult.icon;
        buttons.GetComponentInChildren<TextMeshProUGUI>().text = cookResult.Name;
    }

    // Update is called once per frame
    void Update()
    {
        ItemSlot itemSlot = GameManager.instance.inventoryContainer.slots.Find(x => x.item == cookItem);

        if (itemSlot != null)
        {
            buttons.interactable = true;
        }
        else
        {
            buttons.interactable = false;
        }
        
    }

    public void ButtonFunction()
    {
        if(CampFireInteract.instace.doneCooking == false)
        {
            CampFireInteract.instace.CookingPanel.SetActive(false);
            if(progressBar.value > progressBar.minValue)
            {
                progressBar.value -= 1.0f * Time.deltaTime;
            }

            else if(progressBar.value <= 0)
            {
                CampFireInteract.instace.doneCooking = true;
            }

        }

        //if(!doneProgress)
        //{
        //    if (Slider.value > Slider.minValue)
        //    {
        //        Slider.value -= 1.0f * Time.deltaTime;
        //        //percentageNumber = slider.value * 100.0f;
        //    }
        //    else if(Slider.value <= 0)
        //    {
        //        doneProgress = true;

        //    }
        //}
    }
}
