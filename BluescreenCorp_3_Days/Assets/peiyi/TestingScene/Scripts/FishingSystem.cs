using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishingSystem : MonoBehaviour
{
    [Header("Check condition")]
   // bool canFish;
    bool fishing;
    bool openPanel;
    [SerializeField] float distance;

    [Header("Assign")]
    [SerializeField] float staminaUsed;
    [SerializeField] GameObject player;
    [SerializeField] GameObject ProgressBar;
    [SerializeField] GameObject FishingPanel;
    [SerializeField] Item Fish;
    [SerializeField] Sprite sprite;

    [Header("Keycode")]
    [SerializeField] KeyCode FishingKey;

    SpriteRenderer thisSprite;

    // Start is called before the first frame update
    void Start()
    {
        //canFish = false;
        thisSprite = GetComponent<SpriteRenderer>();
        player = GameManager.instance.player;
        ProgressBar = player.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.gameObject.transform.position, GameManager.instance.player.transform.position) < distance)
        {
            if (fishing == false)
            {
                FishingPanel.SetActive(true);
                if (GameManager.instance.hasFishingRod)
                {
                    if (Input.GetKeyDown(FishingKey))
                    {
                        openPanel = !openPanel;
                        FishingPanel.SetActive(openPanel);
                        fishing = true;
                        ProgressBar.SetActive(true);
                        //FishingProgression();

                    }
                }
            }
        }

        else
        {
            FishingPanel.SetActive(false);
        }

        TextUpdate();
        FishingProgression();
    }

    void FishingProgression()
    {
        if(fishing == true)
        {
            FishingPanel.SetActive(false);
            //GameManager.instance.inventoryContainer.RemoveItem(itemSlot.item, 1);
            if (ProgressBar.GetComponentInChildren<Slider>().value > 0)
            {
                ProgressBar.GetComponentInChildren<Slider>().value -= Time.deltaTime;
                CharacterController2D.instance.stopMove = true;
            }

            else if (ProgressBar.GetComponentInChildren<Slider>().value <= 0)
            {
                GameManager.instance.inventoryContainer.AddItem(Fish, 1);
                PlayerStatusManager.instance.PlayerStamina.value -= staminaUsed;
                fishing = false;
                ProgressBar.GetComponentInChildren<Slider>().value = ProgressBar.GetComponentInChildren<Slider>().maxValue;
                CharacterController2D.instance.stopMove = false;
                ProgressBar.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        ProgressBar.GetComponentInChildren<Slider>().value = ProgressBar.GetComponentInChildren<Slider>().maxValue;
    }
    //void SetupProgression()
    //{
    //    if (fishing == false)
    //    {
    //        FishingPanel.SetActive(false);
    //        //GameManager.instance.inventoryContainer.RemoveItem(itemSlot.item, 1);
    //        if (ProgressBar.GetComponentInChildren<Slider>().value > 0)
    //        {
    //            ProgressBar.GetComponentInChildren<Slider>().value -= Time.deltaTime;
    //            CharacterController2D.instance.stopMove = true;
    //        }

    //        else if (ProgressBar.GetComponentInChildren<Slider>().value <= 0)
    //        {
    //            ProgressBar.GetComponentInChildren<Slider>().value = ProgressBar.GetComponentInChildren<Slider>().maxValue;
    //            thisSprite.sprite = sprite; 
    //            CharacterController2D.instance.stopMove = false;
    //            ProgressBar.SetActive(false);
    //        }
    //    }
    //}

    void TextUpdate()
    {
        TextMeshProUGUI panelText = FishingPanel.GetComponentInChildren<TextMeshProUGUI>();
        if(GameManager.instance.hasFishingRod == false)
        {
            panelText.text = "You don't have fishing rod yet.\nYou can craft it throgh crafting page.";
        }

        else
        {
            //if(canFish == false)
            //{
            //    panelText.text = "You have to setup your fishing rod here.\nPress '" + FishingKey + "' to setup.";
            //}

            //else
            //{
                panelText.text = "Press '" + FishingKey + "' to fish.";
            //}
        }
    }
    
    void DoAction()
    {
        if(GameManager.instance.hasFishingRod)
        {
            if (Input.GetKeyDown(FishingKey))
            {
                //if (canFish)
                //{
                    if (fishing == false)
                    {
                        fishing = true;
                        FishingProgression();
                    }
                //}

                //else
                //{
                //    SetupProgression();
                //}
            }
        }
    }
}
