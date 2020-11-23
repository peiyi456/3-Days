using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSword : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "WoodSword";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        // TODO: Add logic what happens when axe is picked up by player
        gameObject.SetActive(false);
    }
}
