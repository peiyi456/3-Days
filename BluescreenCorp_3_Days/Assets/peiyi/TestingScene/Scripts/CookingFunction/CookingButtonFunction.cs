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

    ItemSlot itemSlot;

    [SerializeField] CampFireInteract campFireInteract;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = campFireInteract.ProgressBar.GetComponentInChildren<Slider>();
        buttons.transform.GetChild(0).GetComponent<Image>().sprite = cookResult.icon;
        buttons.GetComponentInChildren<TextMeshProUGUI>().text = cookResult.Name;
    }

    // Update is called once per frame
    void Update()
    {
        itemSlot = GameManager.instance.inventoryContainer.slots.Find(x => x.item == cookItem);

        if (itemSlot != null)
        {
            if (itemSlot.itemCount > 0)
            {
                buttons.interactable = true;
            }
            else
            {
                buttons.interactable = false ;
            }
        }
        else
        {
            buttons.interactable = false;
        }
        
        //if(CampFireInteract.instace.Cooking == true)
        //{
        //    if (progressBar.value > 0)
        //    {
        //        progressBar.value -= Time.deltaTime;
        //    }

        //    else if (progressBar.value <= 0)
        //    {
        //        dropCookedItem();
        //        CampFireInteract.instace.Cooking = false;
        //    }
        //}

        //else
        //{
        //    progressBar.value = progressBar.maxValue;
        //}

    }

    public void ButtonFunction()
    {
        if(CampFireInteract.instace.Cooking == false)
        {
            campFireInteract.cookResult = cookResult;
            //CampFireInteract.instace.cookItem = cookItem;
            campFireInteract.CookingPanel.SetActive(false);
            campFireInteract.ProgressBar.SetActive(true);
            Debug.Log("open");
            GameManager.instance.inventoryContainer.RemoveItem(itemSlot.item, 1);
            Debug.Log("1");
            campFireInteract.Cooking = true;
            //if (progressBar.value > progressBar.minValue)
            //{
            //    CampFireInteract.instace.Cooking = true;
            //    progressBar.value -= 1.0f * Time.deltaTime;
            //}

            //else if(progressBar.value <= 0)
            //{
            //    dropCookedItem();
            //    CampFireInteract.instace.Cooking = false;
            //}

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

    void dropCookedItem()
    {

        Vector3 position = transform.position;
        position.x += (CampFireInteract.instace.spread * UnityEngine.Random.value - CampFireInteract.instace.spread / 2) + 0.5f;
        position.y += (CampFireInteract.instace.spread * UnityEngine.Random.value - CampFireInteract.instace.spread / 2) + 0.5f;
        position.z = -36.34118f;

        ItemSpawnManager.instance.SpawnItem(position, cookResult, 1);
        
        SoundManager.instance.soundEffect.PlayOneShot(CampFireInteract.instace.doneCookSoundEffect);

    }
}
