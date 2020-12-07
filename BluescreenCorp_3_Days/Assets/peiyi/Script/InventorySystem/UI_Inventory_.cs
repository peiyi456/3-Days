using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory_ : MonoBehaviour
{
    private Inventory_ inventory_;
    private Transform itemSlotContainer;
    private Transform itemSlot;

    private void Awake()
    {
        itemSlotContainer = transform.Find("Inventory_2nd");
        itemSlot = itemSlotContainer.Find("Slot");
    }

    public void SetInventory_(Inventory_ inventory_)
    {
        this.inventory_ = inventory_;
        RefreshInventoryItems_();
    }

    private void RefreshInventoryItems_()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 245f;

        foreach(Item_ item in inventory_.GetItemList_())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x++;
            if(x > 3)
            {
                x = 0;
                y++;
            }
        }
    }
}
