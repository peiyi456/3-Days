using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPage : MonoBehaviour
{
    public InventorySystem inventory;

    public GameObject messagePanel;

    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
        inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory_2nd");
        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++;

            //Border... Image
            Transform imageTransfrom = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransfrom.GetComponent<Image>();
            TextMeshProUGUI txtCount = textTransform.GetComponent<TextMeshProUGUI>();
            ItemDragHandler itemDragHandler = imageTransfrom.GetComponent<ItemDragHandler>();

            if (index == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                int itemCount = e.Item.Slot.Count;
                if (itemCount > 1)
                    txtCount.text = itemCount.ToString();
                else
                    txtCount.text = "";

                //Store a reference to the item
                itemDragHandler.Item = e.Item;

                break;
            }

            //We found the empty slot
            //if (!image.enabled)
            //{
            //    image.enabled = true;
            //    image.sprite = e.Item.Image;

            //    //TODO: Store a reference to the item

            //    break;
            //}
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory_2nd");
        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++;

            //Border... Image
            Transform imageTransfrom = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransfrom.GetComponent<Image>();
            TextMeshProUGUI txtCount = textTransform.GetComponent<TextMeshProUGUI>();
            ItemDragHandler itemDragHandler = imageTransfrom.GetComponent<ItemDragHandler>();

            //We found the item in the UI
            if (itemDragHandler.Item == null)
                continue;

            //Found the slot to remove from
            if (e.Item.Slot.Id == index)
            {
                int itemCount = e.Item.Slot.Count;
                itemDragHandler.Item = e.Item.Slot.FirstItem;

                if (itemCount < 2)
                {
                    txtCount.text = "";
                }
                else
                {
                    txtCount.text = itemCount.ToString();
                }

                if (itemCount == 0)
                {
                    image.enabled = false;
                    image.sprite = null;
                }
                break;
            }

            if (index == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                int itemCount = e.Item.Slot.Count;
                if (itemCount > 1)
                    txtCount.text = itemCount.ToString();
                else
                    txtCount.text = "";

                //Store a reference to the item
                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    public void OpenMessagePanel(string text)
    {
        messagePanel.SetActive(true);
    }

    public void CloseMessagePanel()
    {
        messagePanel.SetActive(false);
    }
}
