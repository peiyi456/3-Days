using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutKeyFunction : MonoBehaviour
{
    //[SerializeField] KeyCode keyCode;
    //[SerializeField] InventoryButton buttons;
    ItemContainer inventory;
    bool press;

    // Start is called before the first frame update
    void Start()
    {
        press = false;
    }

    // Update is called once per frame
    void Update()
    {
        inventory = GameManager.instance.inventoryContainer;
        if (Input.GetKey(KeyCode.Alpha5))
        {
            inventory.RemoveItem(inventory.slots[9].item, 1);
        }
        
    }
}
