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
        pageStatusSortingNumber = 7;
        pageInventorySortingNumber = 3;
        pageCraftingSortingNumber = 4;
        pageAnimalsSortingNumber = 5;
        pageInformationSortingNumber = 1;

        isTriggerStatus = false;
        isTriggerInventory = false;
        isTriggerCrafting = false;
        isTriggerAnimals = false;
        isTriggerInformation = false;

    }
    void getSpiriteRendererUpdate()
    {
        pageStatus.GetComponent<Canvas>().sortingOrder = pageStatusSortingNumber;
        pageInventory.GetComponent<Canvas>().sortingOrder = pageInventorySortingNumber;
        pageCrafting.GetComponent<Canvas>().sortingOrder = pageCraftingSortingNumber;
        pageAnimals.GetComponent<Canvas>().sortingOrder = pageAnimalsSortingNumber;
        pageInformation.GetComponent<Canvas>().sortingOrder = pageInformationSortingNumber;
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
            isTriggerStatus = false;
        }

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
            isTriggerInventory = false;
        }

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
    }
    void Update()
    {
        getSpiriteRendererUpdate();
    }

    void LateUpdate()
    {
        TriggerChangingStatus();
        TriggerChangingInventory();
        TriggerChangingAnimals();
        TriggerChangingCrafting();
        TriggerChangingInformation();
    }
    void FixedUpdate()
    {

    }
}
