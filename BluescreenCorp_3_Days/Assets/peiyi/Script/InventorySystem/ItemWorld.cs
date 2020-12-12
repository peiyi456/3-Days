using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item_ item)
    {
        Transform transform = Instantiate(ItemAssets_.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item_ item;
    private SpriteRenderer spriteRenderer;
    public GameObject pickupReminder;
    public SpriteRenderer mapIcon;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    public void SetItem(Item_ item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        mapIcon.sprite = item.GetSprite();
    }

    public Item_ GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void OpenMessagePanel()
    {
        pickupReminder.SetActive(true);
    }

    public void CloseMessagePanel()
    {
        pickupReminder.SetActive(false);
    }
}
