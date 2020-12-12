using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_
{
    public event EventHandler OnItemListChanged;

    private List<Item_> itemList_;
    private Action<Item_> useItemAction;

    public Inventory_(Action<Item_> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList_ = new List<Item_>();

        //AddItem_(new Item_ { itemType_ = Item_.ItemType_.Axe, amount_ = 0 });
        //AddItem_(new Item_ { itemType_ = Item_.ItemType_.Tools, amount_ = 0 });
        //AddItem_(new Item_ { itemType_ = Item_.ItemType_.Woodsword, amount_ = 0 });
        //AddItem_(new Item_ { itemType_ = Item_.ItemType_.Leave, amount_ = 5 });
        //AddItem_(new Item_ { itemType_ = Item_.ItemType_.Meat, amount_ = 5 });
        //AddItem_(new Item_ { itemType_ = Item_.ItemType_.Stone, amount_ = 5 });
        AddItem_(new Item_ { itemType_ = Item_.ItemType_.Banana, amount_ = 5 });
        AddItem_(new Item_ { itemType_ = Item_.ItemType_.Mango, amount_ = 5 });
        AddItem_(new Item_ { itemType_ = Item_.ItemType_.Log, amount_ = 5 });
    }

    public void AddItem_(Item_ item_)
    {
        if (item_.IsStackable())
        {
            bool itemAlreadtInInventory = false;
            foreach (Item_ inventoryItem in itemList_)
            {
                if (inventoryItem.itemType_ == item_.itemType_)
                {
                    inventoryItem.amount_ += item_.amount_;
                    itemAlreadtInInventory = true;
                }
            }

            if (!itemAlreadtInInventory)
            {
                itemList_.Add(item_);
            }
        }
        else
        {
            itemList_.Add(item_);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item_ item_)
    {
        if (item_.IsStackable())
        {
            Item_ itemInInventory = null;
            foreach (Item_ inventoryItem in itemList_)
            {
                if (inventoryItem.itemType_ == item_.itemType_)
                {
                    inventoryItem.amount_ -= item_.amount_;
                    itemInInventory = inventoryItem;
                }
            }

            if (itemInInventory != null && itemInInventory.amount_ <= 0)
            {
                itemList_.Remove(itemInInventory);
            }
        }
        else
        {
            itemList_.Remove(item_);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item_ item_)
    {
        if (item_.IsUsable())
        {
            useItemAction(item_);
        }
    }

    public List<Item_> GetItemList_()
    {
        return itemList_;
    }
}
