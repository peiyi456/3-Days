using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShortcutKeyFunction : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField] KeyCode keyCode;
    //[SerializeField] InventoryButton buttons;
    ItemContainer inventory;

    [Header("Inventory Button No")]
    [SerializeField] int ButtonNo;

    [SerializeField] KeyCode foodShortKey1;
    //[SerializeField] KeyCode foodShortKey2;
    //[SerializeField] KeyCode foodShortKey3;
    [SerializeField] bool press;

    //[Header("Add Value")]
    //[SerializeField] float FoodValue;
    //[SerializeField] float WaterValue;
    //[SerializeField] float HPValue;
    //[SerializeField] Slider hungryStat;
    //[SerializeField] Slider waterStat;
    //[SerializeField] Slider hpStat;


    // Start is called before the first frame update
    void Start()
    {
        inventory = GameManager.instance.inventoryContainer;
        press = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(foodShortKey1))
        {
            StartCoroutine(eatingCDTime(ButtonNo, 2.0f));
        }
        
        
    }

    public void OnPointerClick(PointerEventData eventDate)
    {

        if (eventDate.button == PointerEventData.InputButton.Left)
        {
            StartCoroutine(eatingCDTime(ButtonNo, 2.0f));
        }        
    }

    IEnumerator eatingCDTime(int buttonNo, float time)
    {
        if (press == false)
        {
            inventory.RemoveItem(inventory.slots[buttonNo].item, 1);
            press = true;
            PlayerStatusManager.instance.PlayerFood.value += inventory.slots[buttonNo].item.FoodValue;
            PlayerStatusManager.instance.PlayerWater.value += inventory.slots[buttonNo].item.WaterValue;
            PlayerStatusManager.instance.PlayerHP.value += inventory.slots[buttonNo].item.HPValue;
        }

        yield return new WaitForSeconds(time);
        press = false;
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}

    public void ShowToolTip()
    {

    }
}
