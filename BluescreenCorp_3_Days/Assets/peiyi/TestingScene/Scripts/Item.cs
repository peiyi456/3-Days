using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes { Food, Resources, Tools };


[CreateAssetMenu(menuName ="Data/Item")]
public class Item : ScriptableObject
{

    public string Name;
    public bool stackable;
    public Sprite icon;
    [TextArea] public string Description;
    [TextArea] public string Hint;

    public ItemTypes itemTypes;
}
