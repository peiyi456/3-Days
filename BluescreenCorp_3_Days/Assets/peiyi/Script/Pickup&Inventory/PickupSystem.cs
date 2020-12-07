using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{

    public InventorySystem inventory;

    public InventoryPage inventoryPage;



    void Update()
    {
        if (mItemToPickup != null && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(mItemToPickup);
            //mItemToPickup.OnPickup();
            inventoryPage.CloseMessagePanel();
        }
    }


    private IInventoryItem mItemToPickup = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUpItem")
        {
            IInventoryItem item = collision.GetComponent<IInventoryItem>();
            if (item != null)
            {
                mItemToPickup = item;

                inventory.AddItem(item);
                inventoryPage.OpenMessagePanel("");
                Vector2 temp = collision.transform.position;
                temp.y += 1.2f;
                inventoryPage.messagePanel.transform.position = temp;



            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PickUpItem")
        {
            IInventoryItem item = collision.GetComponent<IInventoryItem>();
            if (item != null)
            {

                //inventory.AddItem(item);
                inventoryPage.CloseMessagePanel();
                mItemToPickup = null;
            }
        }
    }
}
