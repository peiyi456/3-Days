using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/CraftingItemRecipe")]
public class CraftingItemRecipe : ScriptableObject
{
    public List<ItemSlot> elements;
    public ItemSlot output;
}
