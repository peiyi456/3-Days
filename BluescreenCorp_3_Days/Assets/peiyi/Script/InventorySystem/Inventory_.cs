using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_ 
{
    private List<Item_> itemList_;

    public Inventory_()
    {
        itemList_ = new List<Item_>();

        AddItem_(new Item_ { itemType_ = Item_.ItemType_.Axe, amount_ = 1 });
        AddItem_(new Item_ { itemType_ = Item_.ItemType_.Tools, amount_ = 1 });
        AddItem_(new Item_ { itemType_ = Item_.ItemType_.Woodsword, amount_ = 1 });
    }

    public void AddItem_(Item_ item_)
    {
        itemList_.Add(item_);
    }

    public List<Item_> GetItemList_()
    {
        return itemList_;
    }
}
