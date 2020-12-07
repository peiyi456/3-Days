using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : InventoryItemBase
{
    public override string Name
    {
        get
        {
            return "Tools";
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
