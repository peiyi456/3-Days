using System.Collections;
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

    void Start()
    {
        pageStatus.GetComponent<Renderer>().sortingOrder = pageStatusSortingNumber;
        pageInventory.GetComponent<Renderer>().sortingOrder = pageInventorySortingNumber;
        pageCrafting.GetComponent<Renderer>().sortingOrder = pageCraftingSortingNumber;
        pageAnimals.GetComponent<Renderer>().sortingOrder = pageAnimalsSortingNumber;
        pageInformation.GetComponent<Renderer>().sortingOrder = pageInformationSortingNumber;

        pageStatusSortingNumber = 1;
        pageInventorySortingNumber = 3;
        pageCraftingSortingNumber = 4;
        pageAnimalsSortingNumber = 5;
        pageInformationSortingNumber = 6;
    }

    void OnMouseDown()
    {
        if (pageStatusButton)
        {
            pageStatusSortingNumber = 1;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 6;

        }
        if (pageInventoryButton)
        {
            pageStatusSortingNumber = 3;
            pageInventorySortingNumber = 1;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 6;
        }
        if (pageCraftingButton)
        {
            pageStatusSortingNumber = 2;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 1;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 6;
        }
        if (pageAnimalsButton)
        {
            pageStatusSortingNumber = 2;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 1;
            pageInformationSortingNumber = 6;
        }
        if (pageInformationButton)
        {
            pageStatusSortingNumber = 2;
            pageInventorySortingNumber = 3;
            pageCraftingSortingNumber = 4;
            pageAnimalsSortingNumber = 5;
            pageInformationSortingNumber = 1;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (pageAnimalsSortingNumber == 1)
        {
            
        }
    }
    void Update()
    {

    }

    void LateUpdate()
    {
        OnMouseDown();
    }
  
}
