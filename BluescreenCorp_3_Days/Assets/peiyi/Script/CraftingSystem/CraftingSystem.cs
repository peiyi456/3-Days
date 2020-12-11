using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem
{
    public const int GRID_SIZE = 3;

    private Item_[,] itemArray;

    public CraftingSystem()
    {
        itemArray = new Item_[GRID_SIZE, GRID_SIZE];
    }

    public bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    public Item_ GetItem (int x, int y)
    {
        return itemArray[x, y];
    }

    public void SetItem(Item_ item_, int x, int y)
    {
        itemArray[x, y] = item_;
    }

    public void IncreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount_++;
    }

    public void DecreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount_--;
    }

    public void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    public bool TryAddItem(Item_ item_, int x, int y)
    {
        if(IsEmpty(x,y))
        {
            SetItem(item_, x, y);
            return true;
        }

        else
        {
            if(item_.itemType_ == GetItem(x, y).itemType_)
            {
                IncreaseItemAmount(x, y);
                return true;
            }
            
            else
            {
                return false;
            }
        }
    }
}
