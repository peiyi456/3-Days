using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/CraftingRecipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemSlot> elements;
    public ItemSlot output;

    public bool CanCraft(ItemContainer inventory)
    {
        return false;
    }

    public void Craft(ItemContainer inventory)
    {

    }
}
