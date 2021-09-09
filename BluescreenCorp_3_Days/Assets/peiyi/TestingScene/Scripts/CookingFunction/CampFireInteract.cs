﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CampFireInteract : MonoBehaviour
{
    public static CampFireInteract instace;

    [Header("Audio clip")]
    public AudioClip doneCookSoundEffect;

    [Header("Assign")]
    [SerializeField] float staminaUsed;
    GameObject player;
    public GameObject PopupMessage;
    public float distance;
    public GameObject CookingPanel;
    public GameObject ProgressBar;
    public float spread;

    [Header("Keycode")]
    public KeyCode keycode;

    [Header("Checking Used")]
    public bool isPressButton;
    public bool Cooking;
    public static bool isNearCampFire;

    public Item cookResult;
    public Item cookItem;

    ItemSlot itemSlot;

    private void Awake()
    {
        instace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
        ProgressBar.GetComponentInChildren<Slider>().value = 0;
        PopupMessage.GetComponentInChildren<TextMeshProUGUI>().text = "Press '" + keycode.ToString() + "' to cook";
    }

    // Update is called once per frame
    void Update()
    {
        if(CookingPanel.activeSelf == false)
        {
            isPressButton = false;
        }

        else
        {
            GameManager.instance.TextReminder.SetActive(false);
        }

        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) < distance)
        {
            if (Cooking == false)
            {
                PopupMessage.SetActive(true);

                if (Input.GetKeyDown(keycode))
                {
                    isPressButton = !isPressButton;
                    //GameManager.instance.isPause = isPressButton;
                    CookingPanel.SetActive(isPressButton);
                }
            }

            else
            {
                //Cooking = false;
                PopupMessage.SetActive(false);
                CookingPanel.SetActive(false);
                isPressButton = false;
            }

        }

        else
        {
            PopupMessage.SetActive(false);
        }

        CookFunction();
    }

    void CookFunction()
    {
        if (Cooking == true)
        {
            CookingPanel.SetActive(false);
            PopupMessage.SetActive(false);
                Debug.Log("GHe3");
            //GameManager.instance.inventoryContainer.RemoveItem(itemSlot.item, 1);
            if (ProgressBar.GetComponentInChildren<Slider>().value < ProgressBar.GetComponentInChildren<Slider>().maxValue)
            {
                ProgressBar.GetComponentInChildren<Slider>().value += Time.deltaTime;
                Debug.Log("GHe2");
            }

            else if (ProgressBar.GetComponentInChildren<Slider>().value >= ProgressBar.GetComponentInChildren<Slider>().maxValue)
            {
                dropCookedItem();
                Cooking = false;
                ProgressBar.GetComponentInChildren<Slider>().value = 0;
                Debug.Log("GHe");
            }
        }
    }

    void dropCookedItem()
    {

        Vector3 position = transform.position;
        position.x += (spread * UnityEngine.Random.value - spread / 2) + 0.5f;
        position.y += (spread * UnityEngine.Random.value - spread / 2) + 0.5f;
        position.z = -36.34118f;
        ProgressBar.SetActive(false);

        ItemSpawnManager.instance.SpawnItem(position, cookResult, 1);
        PlayerStatusManager.instance.PlayerStamina.value -= staminaUsed;
        SoundManager.instance.soundEffect.PlayOneShot(doneCookSoundEffect);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isNearCampFire = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isNearCampFire = false;
            
        }
    }
}
