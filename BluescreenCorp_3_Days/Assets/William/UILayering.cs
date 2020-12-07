﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILayering : MonoBehaviour
{
    public GameObject pageStatusButton;
    public GameObject pageInventoryButton;
    public GameObject pageCraftingButton;
    public GameObject pageAnimalsButton;
    public GameObject pageInformationButton;

    public GameObject pageStatus;
    public GameObject pageInventory;
    public GameObject pageCrafting;
    public GameObject pageAnimals;
    public GameObject pageInformation;

    public GameObject pageStatusTransform;
    public GameObject pageInventoryTransform;
    public GameObject pageCraftingTransform;
    public GameObject pageAnimalsTransform;
    public GameObject pageInformationTransform;

    int pageStatusSortingNumber;
    int pageInventorySortingNumber;
    int pageCraftingSortingNumber;
    int pageAnimalsSortingNumber;
    int pageInformationSortingNumber;

    bool isTriggerChangingNumber;
    void Start()
    {
        pageStatusSortingNumber = 6;
        pageInventorySortingNumber = 3;
        pageCraftingSortingNumber = 4;
        pageAnimalsSortingNumber = 5;
        pageInformationSortingNumber = 1;
        //initialise staring layer sequece

        pageStatus.GetComponent<SpriteRenderer>().sortingOrder = pageStatusSortingNumber;
        pageInventory.GetComponent<SpriteRenderer>().sortingOrder = pageInventorySortingNumber;
        pageCrafting.GetComponent<SpriteRenderer>().sortingOrder = pageCraftingSortingNumber;
        pageAnimals.GetComponent<SpriteRenderer>().sortingOrder = pageAnimalsSortingNumber;
        pageInformation.GetComponent<SpriteRenderer>().sortingOrder = pageInformationSortingNumber;
        // put in the layer sequence into game object sprite renderer

        isTriggerChangingNumber = false;
    }
    void getSpiriteRendererUpdate()
    {
        pageStatus.GetComponent<SpriteRenderer>().sortingOrder = pageStatusSortingNumber;
        pageInventory.GetComponent<SpriteRenderer>().sortingOrder = pageInventorySortingNumber;
        pageCrafting.GetComponent<SpriteRenderer>().sortingOrder = pageCraftingSortingNumber;
        pageAnimals.GetComponent<SpriteRenderer>().sortingOrder = pageAnimalsSortingNumber;
        pageInformation.GetComponent<SpriteRenderer>().sortingOrder = pageInformationSortingNumber;
    }
    void OnMouseDown()
    {

    }
    void TriggerChanging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (GameObject.Find("pageStatusButton"))
            {
                isTriggerChangingNumber = true;
                {
                    pageStatusSortingNumber = 7;
                    pageInventorySortingNumber = 3;
                    pageCraftingSortingNumber = 4;
                    pageAnimalsSortingNumber = 5;
                    pageInformationSortingNumber = 1;
                    Debug.Log("OI");
                    isTriggerChangingNumber = false;
                }
                
            }
            if (GameObject.Find("pageInventoryButton"))
            {

                isTriggerChangingNumber = true;
                {
                    pageStatusSortingNumber = 3;
                    pageInventorySortingNumber = 6;
                    pageCraftingSortingNumber = 4;
                    pageAnimalsSortingNumber = 5;
                    pageInformationSortingNumber = 1;
                    Debug.Log("Bro");
                    isTriggerChangingNumber = false;
                }
            }
            if (GameObject.Find("pageCraftingButton"))
            {
                isTriggerChangingNumber = true;
                {
                    pageStatusSortingNumber = 2;
                    pageInventorySortingNumber = 3;
                    pageCraftingSortingNumber = 6;
                    pageAnimalsSortingNumber = 5;
                    pageInformationSortingNumber = 1;
                    isTriggerChangingNumber = false;
                }
            }
            if (GameObject.Find("pageAnimalsButton"))
            {
                isTriggerChangingNumber = true;
                {
                    pageStatusSortingNumber = 2;
                    pageInventorySortingNumber = 3;
                    pageCraftingSortingNumber = 4;
                    pageAnimalsSortingNumber = 6;
                    pageInformationSortingNumber = 1;
                    isTriggerChangingNumber = false;
                }
            }
            if (GameObject.Find("pageInformationButton"))
            {
                isTriggerChangingNumber = true;
                {
                    pageStatusSortingNumber = 2;
                    pageInventorySortingNumber = 3;
                    pageCraftingSortingNumber = 4;
                    pageAnimalsSortingNumber = 5;
                    pageInformationSortingNumber = 6;
                    isTriggerChangingNumber = false;
                }
            }
        }
      
    }
    void OnMouseEnter()
    {
        if (pageStatusButton)
        {
        

        }
        if (pageInventoryButton)
        {
           
        }
        if (pageCraftingButton)
        {
            
        }
        if (pageAnimalsButton)
        {
           
        }
        if (pageInformationButton)
        {
            
        }
    }

    void Update()
    {
        OnMouseDown();
        TriggerChanging();
        Debug.Log(pageStatusSortingNumber);
    }

    void LateUpdate()
    {
        getSpiriteRendererUpdate();
    }
  
    void Useless()
    {
        
    }
}
