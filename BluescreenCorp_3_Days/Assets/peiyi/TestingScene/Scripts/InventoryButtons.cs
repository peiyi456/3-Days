using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ItemContainer inventory;

    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI noText;
    //[SerializeField] string name;

    [SerializeField] int myIndex;

    [SerializeField] Image itemImg;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemFunction;
    [SerializeField] TextMeshProUGUI itemHint;
    [SerializeField] bool selected = false;

    Button bttn;

    public bool isShortKey;

    private void Start()
    {
        bttn = GetComponent<Button>();
        inventory = GameManager.instance.inventoryContainer;
    }

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        //name = slot.item.name;

        if(slot.item.stackable == true)
        {
            noText.gameObject.SetActive(true);
            noText.text = slot.count.ToString();
        }
        else
        {
            noText.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        noText.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //ItemContainer inventory = GameManager.instance.inventoryContainer;
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isShortKey)
            {
                GameManager.instance.itemDragAndDropController.OnClickShortKey(inventory.slots[myIndex]);
            }
            else
            {
                GameManager.instance.itemDragAndDropController.OnClick(inventory.slots[myIndex]);
            }
        }
            transform.parent.GetComponent<InventoryPanel>().Show();
    }


    public void ButtonClicked(int buttonNo)
    {
        if(selected == false)
        {
            if (inventory.slots[buttonNo].item != null)
            {
                //itemImg.gameObject.SetActive(true);
                //itemName.gameObject.SetActive(true);
                //itemImg.sprite = inventory.slots[buttonNo].item.icon;
                //itemName.text = inventory.slots[buttonNo].item.Name;
                //selected = true;
                ShowDetail(buttonNo);
            }

            else
            {
                //itemImg.sprite = null;
                //itemName.text = "";
                //itemImg.gameObject.SetActive(false);
                //itemName.gameObject.SetActive(false);
                //selected = false;
                HideDetail(buttonNo);
            }
        }

        else
        {
            //itemImg.sprite = null;
            //itemName.text = "";
            //itemImg.gameObject.SetActive(false);
            //itemName.gameObject.SetActive(false);
            //selected = false;
            HideDetail(buttonNo);
        }
    }

    void ShowDetail(int no)
    {
        itemImg.gameObject.SetActive(true);
        itemName.gameObject.SetActive(true);
        itemFunction.gameObject.SetActive(true);
        itemHint.gameObject.SetActive(true);
        itemImg.sprite = inventory.slots[no].item.icon;
        itemName.text = inventory.slots[no].item.Name;
        itemFunction.text = inventory.slots[no].item.Function;
        itemHint.text = inventory.slots[no].item.Hint;
        selected = true;
    }

    void HideDetail(int no)
    {
        itemImg.sprite = null;
        itemName.text = "";
        itemFunction.text = "";
        itemHint.text = "";
        itemImg.gameObject.SetActive(false);
        itemName.gameObject.SetActive(false);
        itemFunction.gameObject.SetActive(false);
        itemHint.gameObject.SetActive(false);
        selected = false;
    }
}
