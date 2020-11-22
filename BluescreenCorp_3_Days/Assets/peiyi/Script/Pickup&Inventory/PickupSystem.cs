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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInventoryItem item = collision.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            mItemToPickup = item;

            //inventory.AddItem(item);
            inventoryPage.OpenMessagePanel("");


        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IInventoryItem item = collision.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {

            //inventory.AddItem(item);
            inventoryPage.CloseMessagePanel();
            mItemToPickup = null;
        }
    }
}
