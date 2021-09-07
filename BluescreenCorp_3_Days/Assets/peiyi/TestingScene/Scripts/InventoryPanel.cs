using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public static InventoryPanel instance;

    [SerializeField] ItemContainer inventory;
    public List<InventoryButtons> buttons;

    public bool[] selected;
    public bool IsSelectedButton;
    public int SelectedButtonNo;
    public Button ThrowButton;
    public Button UseButton;
    public bool isPressUse;
    //public bool IsThrow;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        selected = new bool[GameManager.instance.inventoryContainer.slots.Count];
        isPressUse = false;
        inventory = GameManager.instance.inventoryContainer;
        GameManager.instance.inventoryContainer.ClearContainer();
        //SetIndex();
        Show();
    }

    //private void Start()
    //{
    //    SetIndex();
    //    Show();

    //}

    private void Update()
    {
        //SetIndex();
        Show();

        if(isPressUse)
        {
            UseButton.interactable = !isPressUse;
        }
        else
        {
            UseButton.interactable = !isPressUse;
        }
    }

    //private void OnEnable()
    //{
    //    Show();
    //}

    public void ShowButtons(bool showButton, ItemSlot slots)
    {
        if (slots != null)
        {
            if (showButton)
            {
                ThrowButton.gameObject.SetActive(true);
                //IsHideDetails = false;

                Debug.Log(slots.item.itemTypes);

                if (slots.item.itemTypes == ItemTypes.Food)
                {
                    UseButton.gameObject.SetActive(true);
                    Debug.Log("DDD");
                }

                //else
                //{
                //    UseButton.gameObject.SetActive(false);
                //}
            }
            else
            {
                ThrowButton.gameObject.SetActive(false);
                UseButton.gameObject.SetActive(false);
                //IsHideDetails = true;
            }
        }
        else
        {
            ThrowButton.gameObject.SetActive(false);
            UseButton.gameObject.SetActive(false);
            //IsHideDetails = true;
        }
    }

    public void ThrowItem()
    {
        inventory.slots[SelectedButtonNo].Clear();
        ThrowButton.gameObject.SetActive(false);
        UseButton.gameObject.SetActive(false);
        buttons[SelectedButtonNo].Clean();

        buttons[SelectedButtonNo].itemImg.gameObject.SetActive(false);
        buttons[SelectedButtonNo].itemName.gameObject.SetActive(false);
        buttons[SelectedButtonNo].itemFunction.gameObject.SetActive(false);
        buttons[SelectedButtonNo].itemHint.gameObject.SetActive(false);
        //IsThrow = true;
        //SelectedButton.Clean();
        //inventory.slots
    }

    public void UseItem()
    {
        StartCoroutine(eatingCDTime(SelectedButtonNo, 2.0f));
    }

    IEnumerator eatingCDTime(int buttonNo, float time)
    {
        if (isPressUse == false)
        {
            inventory.RemoveItem(inventory.slots[buttonNo].item, 1);
            GameManager.instance.soundEffect.PlayOneShot(inventory.slots[buttonNo].item.soundEffect);
            isPressUse = true;
            PlayerStatusManager.instance.PlayerFood.value += inventory.slots[buttonNo].item.FoodValue;
            PlayerStatusManager.instance.PlayerWater.value += inventory.slots[buttonNo].item.WaterValue;
            PlayerStatusManager.instance.PlayerHP.value += inventory.slots[buttonNo].item.HPValue;
        }

        if(inventory.slots[buttonNo].itemCount <= 0)
        {
            ThrowButton.gameObject.SetActive(false);
            UseButton.gameObject.SetActive(false);

            buttons[SelectedButtonNo].Clean();

            buttons[SelectedButtonNo].itemImg.gameObject.SetActive(false);
            buttons[SelectedButtonNo].itemName.gameObject.SetActive(false);
            buttons[SelectedButtonNo].itemFunction.gameObject.SetActive(false);
            buttons[SelectedButtonNo].itemHint.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(time);
        isPressUse = false;
    }

    private void SetIndex()
    {
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
            Debug.Log(buttons[i].gameObject.name + i);
        }
    }

    public void Show()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if(inventory.slots[i].item == null || inventory.slots[i].itemCount <= 0)
            {
                Debug.Log("11");
                //buttons[i].Clean();
                CleanButton(i);
                inventory.slots[i].Clear();
            }
            else
            {
                Debug.Log("22");
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

    public void CleanButton(int i)
    {
        buttons[i].icon.sprite = null;
        buttons[i].icon.gameObject.SetActive(false);
        buttons[i].noText.gameObject.SetActive(false);
        //buttons[i].itemName.text = "";
        //buttons[i].itemFunction.text = "";
        //buttons[i].itemHint.text = "";
        //buttons[i].selected = false;
    }
    //private void ClearContainer()
    //{
    //    //ItemContainer container = FindObjectOfType<ItemContainer>();

    //    for (int i = 0; i < inventory.slots.Count; i++)
    //    {
    //        Debug.Log("000");
    //        inventory.slots[i].Clear();
    //    }

    //}
}
