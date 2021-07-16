using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    [Range(1, 999)]
    public int Amount;
}


[CreateAssetMenu(menuName = "Data/CraftingRecipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemSlot> elements;
    public ItemSlot output;

    public bool CanCraft(ItemContainer inventory)
    {
        IList list = elements;
        for (int i = 0; i < list.Count; i++)
        {
            ItemAmount itemAmount = (ItemAmount)list[i];
            if (inventory.ItemCount(itemAmount.Item) < itemAmount.Amount)
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(ItemContainer inventory)
    {
        if(CanCraft(inventory))
        {
            IList list = elements;
            for (int i1 = 0; i1 < list.Count; i1++)
            {
                ItemAmount itemAmount = (ItemAmount)list[i1];
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    inventory.RemoveItem(itemAmount.Item, itemAmount.Amount);
                }
            }


            
        }
    }
}
