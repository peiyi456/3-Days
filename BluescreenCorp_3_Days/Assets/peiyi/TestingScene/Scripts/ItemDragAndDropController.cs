using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject dragItemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = dragItemIcon.GetComponent<RectTransform>();
        itemIconImage = dragItemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if(dragItemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Click");
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnManager.instance.SpawnItem(
                        worldPosition,
                        itemSlot.item,
                        itemSlot.count
                        );

                    itemSlot.Clear();
                    dragItemIcon.SetActive(false);
                }
            }
        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if (this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;
            ItemTypes itemTypes = itemSlot.itemTypes;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count, itemTypes);
        }

        UpdateIcon();
    }

    internal void OnClickShortKey(ItemSlot itemSlot)
    {
        if (this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            if (this.itemSlot.item.itemTypes == ItemTypes.Food)
            {
                Item item = itemSlot.item;
                int count = itemSlot.count;
                ItemTypes itemTypes = itemSlot.itemTypes;

                itemSlot.Copy(this.itemSlot);
                this.itemSlot.Set(item, count, itemTypes);
            }
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null )
        {
            dragItemIcon.SetActive(false);
        }
        else
        {
            dragItemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
