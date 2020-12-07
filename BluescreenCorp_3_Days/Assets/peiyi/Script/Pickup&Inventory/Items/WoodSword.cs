using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSword : InventoryItemBase
{
    public override string Name
    {
        get
        {
            return "WoodSword";
        }
    }

    public override void OnUse()
    {
        base.OnUse();
    }

    public override void OnPickup()
    {
        base.OnPickup();
    }
}
