using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    private const int GRID_SIZE = 3;

    private Item_[,] itemArray;

    public CraftingSystem()
    {
        itemArray = new Item_[GRID_SIZE, GRID_SIZE];
    }

    private bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    private Item_ GetItem (int x, int y)
    {
        return itemArray[x, y];
    }

    private void SetItem(Item_ item_, int x, int y)
    {
        itemArray[x, y] = item_;
    }

    private void IncreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount_++;
    }

    private void DecreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount_--;
    }

    private void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    private bool TryAddItem(Item_ item_, int x, int y)
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
