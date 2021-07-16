using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] string name;

    [SerializeField] int myIndex;

    [SerializeField] Image itemImg;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] bool selected = false;

    Button bttn;

    private void Start()
    {
        bttn = GetComponent<Button>();
    }

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        name = slot.item.name;

        if(slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemContainer inventory = GameManager.instance.inventoryContainer;
        GameManager.instance.itemDragAndDropController.OnClick(inventory.slots[myIndex]);
        transform.parent.GetComponent<InventoryPanel>().Show();
    }

    public void ButtonClicked(/*int buttonNo*/)
    {
        if(selected == false)
        {
            itemImg.gameObject.SetActive(true);
            itemName.gameObject.SetActive(true);
            itemImg.sprite = icon.sprite;
            itemName.text = name;
            selected = true;
        }

        else
        {
            itemImg.sprite = null;
            itemName.text = "";
            itemImg.gameObject.SetActive(false);
            itemName.gameObject.SetActive(false);
            selected = false;
        }
    }
}
