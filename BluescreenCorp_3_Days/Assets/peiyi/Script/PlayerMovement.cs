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

    }

    

    private ItemWorld itemToPickup = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        itemWorld.OpenMessagePanel();

        if (itemWorld != null)
        {

            itemToPickup = itemWorld; 
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
            //case Item_.ItemType_.Axe:
            //    inventory_.RemoveItem(new Item_ { itemType_ = Item_.ItemType_.Axe, amount_ = 1 });
            //    break;

            //case Item_.ItemType_.CampingSite:
            //    inventory_.RemoveItem(new Item_ { itemType_ = Item_.ItemType_.CampingSite, amount_ = 1 });
            //    break;

            //case Item_.ItemType_.BluntKnife:
            //    inventory_.RemoveItem(new Item_ { itemType_ = Item_.ItemType_.BluntKnife, amount_ = 1 });
            //    break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (itemToPickup != null && Input.GetKeyDown(KeyCode.E))
        {
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
