using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILayering : MonoBehaviour
{
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

    public bool isTriggerStatus;
    public bool isTriggerInventory;
    public bool isTriggerCrafting;
    public bool isTriggerAnimals;
    public bool isTriggerInformation;

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

        isTriggerStatus = false;
        isTriggerInventory = false;
        isTriggerCrafting = false;
        isTriggerAnimals = false;
        isTriggerInformation = false;

    }
    void getSpiriteRendererUpdate()
    {
        pageStatus.GetComponent<SpriteRenderer>().sortingOrder = pageStatusSortingNumber;
        pageInventory.GetComponent<SpriteRenderer>().sortingOrder = pageInventorySortingNumber;
        pageCrafting.GetComponent<SpriteRenderer>().sortingOrder = pageCraftingSortingNumber;
        pageAnimals.GetComponent<SpriteRenderer>().sortingOrder = pageAnimalsSortingNumber;
        pageInformation.GetComponent<SpriteRenderer>().sortingOrder = pageInformationSortingNumber;
    }
    void TriggerChangingStatus()
    {
        if (isTriggerStatus == true)
        {
            pageStatusSortingNumber = 7;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 1;
            Debug.Log("OI");
            isTriggerStatus = false;
        }
        else
            return;
    }
    void TriggerChangingInventory()
    {
        if (isTriggerInventory == true)
        {
            pageStatusSortingNumber = 3;
            pageInventorySortingNumber = 6;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 1;
            Debug.Log("BRO");
            isTriggerInventory = false;
        }
        else
            return;
    }
    void TriggerChangingAnimals()
    {
        if (isTriggerAnimals == true)
        {
            pageStatusSortingNumber = 2;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 6;
            pageInformationSortingNumber = 1;
            isTriggerAnimals = false;
        }
        else
            return;
    }
    void TriggerChangingCrafting()
    {
        if (isTriggerCrafting == true)
        {
            pageStatusSortingNumber = 2;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 6;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 1;
            isTriggerCrafting = false;
        }
        else
            return;
    }
    void TriggerChangingInformation()
    {
        if (isTriggerInformation == true)
        {
            pageStatusSortingNumber = 2;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 6;
            isTriggerInformation = false;
        }
        else
            return;
    }
    void Update()
    {
        TriggerChangingStatus();
        TriggerChangingInventory();
        TriggerChangingAnimals();
        TriggerChangingCrafting();
        TriggerChangingInformation();
        Debug.Log(pageStatusSortingNumber);
    }

    void LateUpdate()
    {
        getSpiriteRendererUpdate();
    }
}
