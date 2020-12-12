using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    Vector2 oriPosition;

    public Inventory_ inventory_;

    [SerializeField] private UI_Inventory_ uiInventory_;

    public AudioSource soundSource;
    public AudioClip pickupSound;

    //public GameObject pickupReminder;

    private void Awake()
    {
        inventory_ = new Inventory_(UseItem);
        uiInventory_.SetInventory_(inventory_);
    }


    // Start is called before the first frame update
    void Start()
    {
        //this.oriPosition = new Vector2(-24.2f, -0.7f);
    }

    

    private ItemWorld itemToPickup = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUpItem"))
        {
            ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
            itemWorld.OpenMessagePanel();


            if (itemWorld != null)
            {

                itemToPickup = itemWorld;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            itemWorld.CloseMessagePanel();

        }
    }

    private void UseItem(Item_ item)
    {
        switch (item.itemType_)
        {
            case Item_.ItemType_.Meat:
                inventory_.RemoveItem(new Item_ { itemType_ = Item_.ItemType_.Meat, amount_ = 1 });
                break;

            case Item_.ItemType_.Mango:
                inventory_.RemoveItem(new Item_ { itemType_ = Item_.ItemType_.Banana, amount_ = 1 });
                break;

            case Item_.ItemType_.Banana:
                inventory_.RemoveItem(new Item_ { itemType_ = Item_.ItemType_.Mango, amount_ = 1 });
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (itemToPickup != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("HI");
            inventory_.AddItem_(itemToPickup.GetItem());
            itemToPickup.DestroySelf();
            soundSource.PlayOneShot(pickupSound);
        }

        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //public void OpenMessagePanel()
    //{
    //    pickupReminder.SetActive(true);
    //}

    //public void CloseMessagePanel()
    //{
    //    pickupReminder.SetActive(false);
    //}

}
