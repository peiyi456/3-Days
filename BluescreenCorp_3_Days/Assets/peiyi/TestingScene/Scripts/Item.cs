using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes { Food, Resources, Tools };


[CreateAssetMenu(menuName ="Data/Item")]
public class Item : ScriptableObject
{
    [Header("Item Details")]
    public string Name;
    public bool stackable;
    public Sprite icon;
    [TextArea] public string Function;
    [TextArea] public string Hint;

    [Header("Item Types")]
    public ItemTypes itemTypes;
    //public bool isMeat;
    //public bool canCook;

    [Header("Adding Status Value When Use")]
    public float FoodValue;
    public float WaterValue;
    public float HPValue;
    public float TemperatureValue;
}
