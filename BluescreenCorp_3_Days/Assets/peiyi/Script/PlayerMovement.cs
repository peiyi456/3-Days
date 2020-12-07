using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public static PlayerMovement Instance { get; private set; }

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    //[SerializeField] private InventoryPage inventoryPage;

    //private Inventory inventory;

    public InventorySystem inventory;

    //public Inventory_ inventory_;

    //[SerializeField] private UI_Inventory_ uiInventory_;

    //public GameObject Hand;


    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        //Do sth with the item 
    }

    //private void Awake()
    //{
    //    inventory_ = new Inventory_();
    //    uiInventory_.SetInventory_(inventory_);

    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
    //    if (itemWorld != null)
    //    {
    //        //Touching Item
    //        inventory.AddItem(itemWorld.GetItem());
    //        itemWorld.DestroySelf();
    //    }
    //}


    // Update is called once per frame
    private void Update()
    {
        

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



    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
    //    if (item != null)
    //    {
    //        inventory.AddItem(item);
    //    }
    //}
}
