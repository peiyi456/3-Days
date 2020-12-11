using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private UI_Inventory_ uiInventory;

    //[SerializeField] 

    private void Start()
    {
        //uiInventory.SetInventory_(playe)
        CraftingSystem craftingSystem = new CraftingSystem();
        //Item_ item = new Item_ { itemType_ = Item_.ItemType_.Axe, amount_ = 1 };
        //craftingSystem.SetItem(item, 0, 0);
        //Debug.Log(craftingSystem.GetItem(0, 0));
    }
}
