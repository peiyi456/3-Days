using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName ="Data/Item Container")]
public class ItemContainer : ScriptableObject , IItemContainer
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        if (item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if(itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            //add non stackable item to ours item container
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if(itemSlot != null)
            {
                itemSlot.item = item;
            }
        }

    }

    //Checking
    public void Remove(Item item, int count = 1)
    {
        if (item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot.count >= 0)
            {
                itemSlot.count -= 1;
            }

            else
            {
                itemSlot.Clear();
            }
        }
        else
        {
            //add non stackable item to ours item container
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }

    //public void IsFull()
    //{
    //    for(int i = 0; i < slots.Count; i++)
    //    {
    //        ItemSlot itemSlot = slots.Find(x => x.item == null);
    //        if(itemSlot )
    //    }
    //}

    public void ClearContainer()
    {

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].item = null;
            slots[i].count = 0;
        }
    }



    /**** Do checking for this!!!! Important ****/
    public bool ContainsItem(Item item)
    {
        throw new NotImplementedException();
    }

    public bool RemoveItem(Item item)
    {
        throw new NotImplementedException();
    }

    public bool AddItem(Item item)
    {
        throw new NotImplementedException();
    }

    public bool IsFull()
    {
        throw new NotImplementedException();
    }
}
