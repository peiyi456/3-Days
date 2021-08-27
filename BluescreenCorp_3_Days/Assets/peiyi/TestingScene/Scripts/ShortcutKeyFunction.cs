using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutKeyFunction : MonoBehaviour
{
    //[SerializeField] KeyCode keyCode;
    //[SerializeField] InventoryButton buttons;
    ItemContainer inventory;
    bool press;
    [SerializeField] Slider hungryStat;
    [SerializeField] Slider waterStat;
    [SerializeField] Slider hpStat;

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
            StartCoroutine(eatingCDTime(2.0f));
            //if (press == false)
            //{
            //    inventory.RemoveItem(inventory.slots[9].item, 1);
            //    press = true;
            //}

        }
        
    }

    IEnumerator eatingCDTime(float time)
    {
        if (press == false)
        {
            inventory.RemoveItem(inventory.slots[9].item, 1);
            press = true;
            hungryStat.value += 5f;
            waterStat.value += 5f;
            hpStat.value += 1f;
        }

        yield return new WaitForSeconds(time);
        press = false;
    }
}
