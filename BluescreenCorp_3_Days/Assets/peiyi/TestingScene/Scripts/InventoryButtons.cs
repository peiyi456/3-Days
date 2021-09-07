using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ItemContainer inventory;

    public Image icon;
    public TextMeshProUGUI noText;
    //[SerializeField] string name;

    [SerializeField] int myIndex;

    public Image itemImg;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemFunction;
    public TextMeshProUGUI itemHint;
    public bool selected = false;
    public bool IsThrow = false;

    [SerializeField] Button bttn;

    public bool isShortKey;

    private void Start()
    {
        bttn = GetComponent<Button>();
        inventory = GameManager.instance.inventoryContainer;
    }

    //private void Update()
    //{
    //    if(inventory.slots[myIndex] == null)
    //    {
    //        HideDetail(myIndex);
    //        selected = false;
    //    }
    //}

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
            noText.text = slot.itemCount.ToString();
        }
        else
        {
            noText.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        Debug.Log("00");
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        noText.gameObject.SetActive(false);
        //InventoryPanel.instance.ShowButtons(false);
        //InventoryPanel.instance.IsHideDetails = true;
        //HideDetail(myIndex);
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

            InventoryPanel.instance.Show();
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
                InventoryPanel.instance.SelectedButtonNo = buttonNo;
                ShowDetail(buttonNo);
                //InventoryPanel.instance.ShowButtons(true);
                //InventoryPanel.instance.IsSelectedButton = selected;
            }

            else
            {
                //itemImg.sprite = null;
                //itemName.text = "";
                //itemImg.gameObject.SetActive(false);
                //itemName.gameObject.SetActive(false);
                //selected = false;
                HideDetail(buttonNo);
                //InventoryPanel.instance.ShowButtons(false);
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

    //void ThrowItem(int no)
    //{

    //}

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
        InventoryPanel.instance.ShowButtons(selected);

        //InventoryPanel.instance.IsHideDetails = false;
    }

    public void HideDetail(int no)
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
        //InventoryPanel.instance.ShowButtons(false);
        //InventoryPanel.instance.IsHideDetails = true;
    }
}
