using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject gettingComponent;
    void Trigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UILayering TriggerChangingInventory = gettingComponent.GetComponent<UILayering>();
            TriggerChangingInventory.isTriggerCrafting = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Trigger();
    }
}
