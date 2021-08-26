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

    public bool AddItem(Item item, int count = 1)
    {
        if (item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if(itemSlot != null)
            {
                itemSlot.count += count;

                if(item.itemTypes == ItemTypes.Food)
                {
                    CollectTargetItem.instance.currentCollectAmount += count;
                }
            }
            else
            {
                itemSlot = slots.Find(x => x.item == null);
                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;

                    if (item.itemTypes == ItemTypes.Food)
                    {
                        CollectTargetItem.instance.currentCollectAmount += count;
                    }
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

        return false;
    }

    //Checking
    public bool RemoveItem(Item item, int count = 1)
    {
        if (item.stackable == true)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot.count >= 0)
            {
                itemSlot.count -= 1;
                if (item.itemTypes == ItemTypes.Food)
                {
                    CollectTargetItem.instance.currentCollectAmount -= count;
                }

                return true;
            }

            else
            {
                itemSlot.Clear();
                if (item.itemTypes == ItemTypes.Food)
                {
                    CollectTargetItem.instance.currentCollectAmount -= count;
                }
                return true;
            }
        }
        else
        {
            //add non stackable item to ours item container
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null)
            {
                itemSlot.item = item;
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            //ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (slots[i].item == null)
            {
                return false;
            }

        }
            return true;
    }

    //public bool ContainsItem(Item item, int count = 1)
    //{
        
    //}

    public int ItemCount(Item item)
    {
        int number = 0;

        for(int i = 0; i < slots.Count; i++)
        {
            if(slots[i].item == item)
            {
                number++;
            }
        }
        return number;
    }

    public void ClearContainer()
    {

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Clear();
        }
    }



    /**** Do checking for this!!!! Important ****/
    //public bool ContainsItem(Item item)
    //{
    //    throw new NotImplementedException();
    //}

    //public bool RemoveItem(Item item)
    //{
    //    throw new NotImplementedException();
    //}

    //public bool AddItem(Item item)
    //{
    //    throw new NotImplementedException();
    //}

    //public bool IsFull()
    //{
    //    throw new NotImplementedException();
    //}
}
