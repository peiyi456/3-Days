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
    public bool thisButton;
    public bool IsThrow = false;

    [SerializeField] Button bttn;

    public bool isShortKey;

    private void Start()
    {
        //selected = false;
        bttn = GetComponent<Button>();
        inventory = GameManager.instance.inventoryContainer;
    }

    private void Update()
    {
        //if(selected)
        //{
        //    if()
        //}
    }

    public void SetIndex(int index)
    {
        myIndex = index;
        //thisButton = selected[index];
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
                HideDetail(InventoryPanel.instance.SelectedButtonNo);
                InventoryPanel.instance.selected[InventoryPanel.instance.SelectedButtonNo] = false;
                InventoryPanel.instance.ShowButtons(false, inventory.slots[InventoryPanel.instance.SelectedButtonNo]) ;

            }
            else
            {
                GameManager.instance.itemDragAndDropController.OnClick(inventory.slots[myIndex]);
                HideDetail(InventoryPanel.instance.SelectedButtonNo);
                InventoryPanel.instance.selected[InventoryPanel.instance.SelectedButtonNo] = false;
                InventoryPanel.instance.ShowButtons(false, inventory.slots[InventoryPanel.instance.SelectedButtonNo]);
            }
        }

        //else if(eventData.button == PointerEventData.InputButton.Left)
        //{
        //    if (!isShortKey)
        //    {
        //        CheckingPress();
        //    }
        //}

            InventoryPanel.instance.Show();
    }


    public void ButtonClicked(int buttonNo)
    {
        if(InventoryPanel.instance.selected[buttonNo] == false)
        {
                InventoryPanel.instance.SelectedButtonNo = buttonNo;
            if (inventory.slots[buttonNo].item != null)
            {
                //InventoryPanel.instance.SelectedButtonNo = buttonNo;
                ShowDetail(buttonNo);
                //ShowDetail(buttonNo);
            }

            else
            {
                HideDetail(buttonNo);
            }
        }

        else
        {
            InventoryPanel.instance.SelectedButtonNo = -1;

            HideDetail(buttonNo);
            //Debug.Log("11111111");
        }

        //if(buttonNo != InventoryPanel.instance.SelectedButtonNo)
        //{
        //    InventoryPanel.instance.ShowButtons(false, inventory.slots[InventoryPanel.instance.SelectedButtonNo]);
        //}
    }

    //void ThrowItem(int no)
    //{

    //}

    public void CheckingPress(int no)
    {
        //selected[no] = !selected[no];
        //for(int i = 0; i < selected.Length; i++)
        //{
        //    selected[i] = false;
        //}
        ////selected[no] = true;

        ////thisButton = !thisButton;
        //selected[no] = !selected[no];

        if (InventoryPanel.instance.selected[no])
        {

            //if (inventory.slots[no].item != null)
            //{
            //    Debug.Log("Not null");
            //    //ShowDetail(InventoryPanel.instance.SelectedButtonNo);
            //    InventoryPanel.instance.ShowButtons(false, inventory.slots[no]);
            //}
            //else
            //{
            //    //HideDetail(InventoryPanel.instance.SelectedButtonNo);
            //    Debug.Log("Null");
            //    InventoryPanel.instance.ShowButtons(false, inventory.slots[no]);
            //}

            InventoryPanel.instance.selected[no] = false;
            InventoryPanel.instance.ShowButtons(InventoryPanel.instance.selected[no], inventory.slots[no]);
        }
        else
        {
            for (int i = 0; i < InventoryPanel.instance.selected.Length; i++)
            {
                InventoryPanel.instance.selected[i] = false;
            }
            InventoryPanel.instance.selected[no] = true;
            //HideDetail(InventoryPanel.instance.SelectedButtonNo);
            if (inventory.slots[no].item != null)
            {
                InventoryPanel.instance.ShowButtons(InventoryPanel.instance.selected[no], inventory.slots[no]);
            }
            else
            {
                InventoryPanel.instance.ShowButtons(false, inventory.slots[no]);
            }
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
        //Debug.Log("selec: " + selected[no]);
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
    }
}
