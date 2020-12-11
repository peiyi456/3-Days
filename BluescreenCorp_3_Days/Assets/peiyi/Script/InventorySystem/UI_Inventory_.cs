using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory_ : MonoBehaviour
{
    private Inventory_ inventory_;
    private Transform itemSlotContainer;
    private Transform itemSlot;

    //private Transform itemDetails;
    //private Transform itemDetails_Image;
    //private Transform itemDetails_itemName;
    //private Transform itemDetails_itemFunc;
    //private Transform itemDetails_itemHints;

    public Image itemDetails_Image;
    public TextMeshProUGUI itemDetails_itemName;
    public TextMeshProUGUI itemDetails_itemFunc;
    public TextMeshProUGUI itemDetails_itemHints;
    public Button button;


    private void Awake()
    {
        itemSlotContainer = transform.Find("Inventory_2nd");
        itemSlot = itemSlotContainer.Find("Slot");

        //itemDetails = transform.Find("ItemDetails");
        //itemDetails_Image =     itemDetails.Find("ItemImage");
        //itemDetails_itemName =  itemDetails.Find("Name");
        //itemDetails_itemFunc =  itemDetails.Find("Funcion");
        //itemDetails_itemHints = itemDetails.Find("Hints");
    }

    public void SetInventory_(Inventory_ inventory_)
    {
        this.inventory_ = inventory_;

        inventory_.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems_();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems_();
    }

    private void RefreshInventoryItems_()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlot) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 245f;

        foreach (Item_ item in inventory_.GetItemList_())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                //Show details
                itemDetails_Image.sprite = item.GetSprite();
                itemDetails_itemName.text = item.GetItemName();
                itemDetails_itemFunc.text = item.GetItemFunc();
                itemDetails_itemHints.text = item.GetItemHints();
                //button = item.GetButtonOn();
            };

            //button.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            //{
            //    //Use item
            //    inventory_.UseItem(item);
            //};

            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                //Use item
                inventory_.UseItem(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("Text").GetComponent<TextMeshProUGUI>();
            if (item.amount_ > 1)
            {
                uiText.SetText(item.amount_.ToString());
            }
            else
            {
                uiText.SetText("");
            }


            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }
        }
    }
}
