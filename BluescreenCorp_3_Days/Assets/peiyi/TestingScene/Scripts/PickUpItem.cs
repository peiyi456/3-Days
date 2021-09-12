using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public AudioClip pickupSound;

    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;

    [SerializeField] KeyCode PickUpKey;

    private void Start()
    {
        player = GameManager.instance.player.transform;
        //soundSource = player.GetComponent<AudioSource>();
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;

        SpriteRenderer miniMapRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        miniMapRenderer.sprite = item.icon;
    }

    private void Update()
    {
        //ttl -= Time.deltaTime;
        //if (ttl < 0) { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickUpDistance)
        { 
            return; 
        }

        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    player.position,
        //    speed * Time.deltaTime
        //    );

        if (distance < pickUpDistance)
        {
            Debug.Log("Pick up");
            if (Input.GetKeyDown(PickUpKey))
            {
                //*TODO* shoud be moved into specific controller rather than being checked here.
                if (GameManager.instance.inventoryContainer != null)
                {
                    ItemSlot itemSlot = GameManager.instance.inventoryContainer.slots.Find(x => x.item == item);
                    if (itemSlot != null)
                    {
                        GameManager.instance.inventoryContainer.AddItem(item, count);
                        SoundManager.instance.soundEffect.PlayOneShot(pickupSound);
                        Destroy(gameObject);

                    }

                    else
                    {
                        ItemSlot itemSlotsss = GameManager.instance.inventoryContainer.slots.Find(x => x.item == null);
                        if (itemSlotsss != null)
                        {
                            if (itemSlotsss.isShortkey == false)
                            {
                                GameManager.instance.inventoryContainer.AddItem(item, count);
                                SoundManager.instance.soundEffect.PlayOneShot(pickupSound);
                                Destroy(gameObject);
                            }

                            else
                            {
                                if(item.itemTypes == ItemTypes.Food)
                                {
                                    GameManager.instance.inventoryContainer.AddItem(item, count);
                                    SoundManager.instance.soundEffect.PlayOneShot(pickupSound);
                                    Destroy(gameObject);
                                }

                                else
                                {
                                    StartCoroutine(InventoryPanel.instance.AppearReminder());
                                }
                            }
                        }

                        else
                        {
                            StartCoroutine(InventoryPanel.instance.AppearReminder());
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("No inventory container attached to the game manager");
                }
            }
        }
    }
}
