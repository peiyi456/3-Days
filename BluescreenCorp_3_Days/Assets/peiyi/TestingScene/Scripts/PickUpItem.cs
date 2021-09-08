﻿using System.Collections;
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
                    GameManager.instance.inventoryContainer.AddItem(item, count);
                    GameManager.instance.soundEffect.PlayOneShot(pickupSound);
                }
                else
                {
                    Debug.LogWarning("No inventory container attached to the game manager");
                }
                Destroy(gameObject);
            }
        }
    }
}
