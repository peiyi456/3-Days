using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting_
{
    private List<CraftItem_> craftList;
    //private Action<Item_> craftItemAction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CraftItem(CraftItem_ craftItem_, Item_ item_A, Item_ item_B)
    {
        bool success = false;

        switch(craftItem_.craftItemType_)
        {
            case CraftItem_.CraftItemType_.Axe:
                if(item_A.amount_ >= 1 && item_B.amount_ > 2)
                {
                    success = true;
                    item_A.amount_ -= 1;
                    item_B.amount_ -= 2;
                }
                break;
            case CraftItem_.CraftItemType_.CampingSite:
                break;
            case CraftItem_.CraftItemType_.BluntKnife:
                break;
            case CraftItem_.CraftItemType_.Spear:
                break;
        }

        return success;
    }
}
