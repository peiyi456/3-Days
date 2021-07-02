using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] List<InventoryButtons> buttons;

    private void Start()
    {
        GameManager.instance.inventoryContainer.ClearContainer();
        SetIndex();
        Show();
    }

    //private void Start()
    //{
    //    SetIndex();
    //    Show();

    //}

    private void Update()
    {
        //SetIndex();
        Show();
    }

    //private void OnEnable()
    //{
    //    Show();
    //}


    private void SetIndex()
    {
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if(inventory.slots[i].item == null)
            {
                //Debug.Log("222");
                buttons[i].Clean();

            }
            else
            {
                //Debug.Log("111");
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

    //private void ClearContainer()
    //{
    //    //ItemContainer container = FindObjectOfType<ItemContainer>();

    //    for (int i = 0; i < inventory.slots.Count; i++)
    //    {
    //        Debug.Log("000");
    //        inventory.slots[i].Clear();
    //    }

    //}
}
