using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingItemSystem : MonoBehaviour
{
    [Header("For shortkey tools used")]
    public bool isAxe, isCampsite, isKnife, isLance, isFishingRod, isTorch;

    [SerializeField] bool craft = false;
    [SerializeField] bool hasElement1, hasElement2, hasElement3;
    [SerializeField] Image element1, element2, element3, output;
    public Button craftBttn;
    [SerializeField] int CraftItemBttnNo;
    [SerializeField] CraftingItemRecipe recipe;
    [SerializeField] ItemContainer container;

    [SerializeField] bool selected = false;

    [SerializeField] Button[] allCraftButton;
    public bool PressButton;
    //[SerializeField] Image/*[]*/ toolsButtonShortKeyImage;

    private void Update()
    {
        //craftBttn.gameObject.SetActive(false);
        //checkingButtonInteractable();
        CanCraft(container);
    }

    public void HideCraftButton(Button bttn)
    {
        for (int i = 0; i < allCraftButton.Length; i++)
        {
            allCraftButton[i].GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(false);
            allCraftButton[i].GetComponent<CraftingItemSystem>().PressButton = false;
            //allCraftButton[i].GetComponent<CraftingItemSystem>().PressButton = false;
        }

        bttn.GetComponent<CraftingItemSystem>().PressButton = !bttn.GetComponent<CraftingItemSystem>().PressButton;
        bttn.GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(bttn.GetComponent<CraftingItemSystem>().PressButton);

        if (bttn.GetComponent<CraftingItemSystem>().isAxe)
        {
            if (GameManager.instance.hasAxe)
            {
                craftBttn.gameObject.SetActive(false);
                //craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                bttn.GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(bttn.GetComponent<CraftingItemSystem>().PressButton);
            }
        }

        if (bttn.GetComponent<CraftingItemSystem>().isCampsite)
        {
            if (GameManager.instance.hasCampsite)
            {
                craftBttn.gameObject.SetActive(false);
                //craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                bttn.GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(bttn.GetComponent<CraftingItemSystem>().PressButton);
            }
        }

        if (bttn.GetComponent<CraftingItemSystem>().isTorch)
        {
            if (GameManager.instance.hasTorch)
            {
                craftBttn.gameObject.SetActive(false);
                //craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                bttn.GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(bttn.GetComponent<CraftingItemSystem>().PressButton);
            }
        }

        if (bttn.GetComponent<CraftingItemSystem>().isFishingRod)
        {
            if (GameManager.instance.hasFishingRod)
            {
                craftBttn.gameObject.SetActive(false);
                //craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                bttn.GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(bttn.GetComponent<CraftingItemSystem>().PressButton);
            }
        }

        if (bttn.GetComponent<CraftingItemSystem>().isKnife)
        {
            if (GameManager.instance.hasKnife)
            {
                craftBttn.gameObject.SetActive(false);
                //craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                bttn.GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(bttn.GetComponent<CraftingItemSystem>().PressButton);
            }
        }

        if (bttn.GetComponent<CraftingItemSystem>().isLance)
        {
            if (GameManager.instance.hasLance)
            {
                craftBttn.gameObject.SetActive(false);
                //craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                bttn.GetComponent<CraftingItemSystem>().craftBttn.gameObject.SetActive(bttn.GetComponent<CraftingItemSystem>().PressButton);
            }
        }
    }


    void checkingButtonInteractable()
    {
        if(isAxe)
        {
            if(GameManager.instance.hasAxe)
            {
                craftBttn.gameObject.SetActive(false);
                craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                craftBttn.gameObject.SetActive(true);
            }
        }

        if (isCampsite)
        {
            if (GameManager.instance.hasCampsite)
            {
                craftBttn.gameObject.SetActive(false);
                craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                craftBttn.gameObject.SetActive(true);
            }
        }

        if (isTorch)
        {
            if (GameManager.instance.hasTorch)
            {
                craftBttn.gameObject.SetActive(false);
                craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                craftBttn.gameObject.SetActive(true);
            }
        }

        if (isFishingRod)
        {
            if (GameManager.instance.hasFishingRod)
            {
                craftBttn.gameObject.SetActive(false);
                craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                craftBttn.gameObject.SetActive(true);
            }
        }

        if (isKnife)
        {
            if (GameManager.instance.hasKnife)
            {
                craftBttn.gameObject.SetActive(false);
                craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                craftBttn.gameObject.SetActive(true);
            }
        }

        if (isLance)
        {
            if (GameManager.instance.hasLance)
            {
                craftBttn.gameObject.SetActive(false);
                craftBttn.interactable = false;
            }
            else
            {
                //craftBttn.interactable = true;
                craftBttn.gameObject.SetActive(true);
            }
        }
    }

    public void CanCraft(ItemContainer inventory)
    {
        //element1.color = Color.black;
        //element2.color = Color.black;

        //output.sprite = recipe.output.item.icon;

        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == recipe.elements[0].item)
            {
                //element1.sprite = inventory.slots[i].item.icon;
                //element1.color = Color.white;
                if (inventory.slots[i].itemCount >= recipe.elements[0].itemCount)
                {
                    hasElement1 = true;
                    //element1.color = Color.white;
                }
                else
                {
                    hasElement1 = false;
                }
            }
            //else
            //{
            //    element1.color = Color.black;
            //}

            if (recipe.elements.Count > 1)
            {
                if (inventory.slots[i].item == recipe.elements[1].item)
                {
                    //element2.sprite = inventory.slots[i].item.icon;
                    //element2.color = Color.white;
                    if (inventory.slots[i].itemCount >= recipe.elements[1].itemCount)
                    {
                        hasElement2 = true;
                        //element2.color = Color.white;
                    }
                    else
                    {
                        hasElement2 = false;
                    }
                }
            }
            //else
            //{
            //    element2.color = Color.black;
            //}

            if (recipe.elements.Count > 2)
            {
                if (inventory.slots[i].item == recipe.elements[2].item)
                {
                    //element2.sprite = inventory.slots[i].item.icon;
                    //element2.color = Color.white;
                    if (inventory.slots[i].itemCount >= recipe.elements[2].itemCount)
                    {
                        hasElement3 = true;
                        //element2.color = Color.white;
                    }
                    else
                    {
                        hasElement3 = false;
                    }
                }
            }
            //else
            //{
            //    element2.color = Color.black;
            //}

        }

        if (recipe.elements.Count < 2)
        {
            if (hasElement1 == true)
            {
                if (!craft)
                {
                    craftBttn.interactable = true;
                    //checkingButtonInteractable();
                    //output.color = Color.white;
                    this.craft = true;
                }
            }

            else
            {
                //craftBttn.interactable = false;
                //output.color = Color.black;
            }
        }

        else if (recipe.elements.Count < 3)
        {
            if (hasElement1 == true && hasElement2 == true)
            {
                if (!craft)
                {
                    //checkingButtonInteractable();
                    craftBttn.interactable = true;
                    //output.color = Color.white;
                    this.craft = true;
                }
            }

            else
            {
                //craftBttn.interactable = false;
                //output.color = Color.black;
            }
        }
        else
        {
            if (hasElement1 == true && hasElement2 == true && hasElement3 == true)
            {
                if (!craft)
                {
                    //checkingButtonInteractable();
                    craftBttn.interactable = true;
                    //output.color = Color.white;
                    this.craft = true;
                }
            }

            else
            {
                //craftBttn.interactable = false;
                //output.color = Color.black;
            }

        }
    }

    public void ButtonClicked()
    {
        //CraftItemBttnNo = ButtonNo;
        if(!PressButton)
        {
            checkingButtonInteractable();
            element1.gameObject.SetActive(true);
            element2.gameObject.SetActive(true);
            element3.gameObject.SetActive(true);
            output.gameObject.SetActive(true);
            craftBttn.gameObject.SetActive(true);
            element1.sprite = recipe.elements[0].item.icon;
            output.sprite = recipe.output.item.icon;
            if(hasElement1)
            {
                element1.color = Color.white;
            }
            else
            {
                element1.color = Color.black;
            }

            if (recipe.elements.Count > 1)
            {
                element2.sprite = recipe.elements[1].item.icon;
                if (hasElement2)
                {
                    element2.color = Color.white;
                }
                else
                {
                    element2.color = Color.black;
                }
            }

            else
            {
                element2.sprite = null;
                element2.gameObject.SetActive(false);

                element3.sprite = null;
                element3.gameObject.SetActive(false);
            }

            if (recipe.elements.Count > 2)
            {
                element3.sprite = recipe.elements[2].item.icon;
                if (hasElement3)
                {
                    element3.color = Color.white;
                }
                else
                {
                    element3.color = Color.black;
                }
            }

            else
            {
                element3.sprite = null;
                element3.gameObject.SetActive(false) ;
            }
            //element1.sprite = icon.sprite;
            //itemName.text = name;
            selected = true;
            //craftBttn.gameObject.SetActive(true);
        }
        else
        {
            element1.gameObject.SetActive(false);
            element2.gameObject.SetActive(false);
            element3.gameObject.SetActive(false);
            output.gameObject.SetActive(false);
            craftBttn.gameObject.SetActive(false);
            selected = false;
            craftBttn.gameObject.SetActive(false);
        }
    }

    public void CraftItem(Item item)
    {
        for (int i = 0; i < container.slots.Count; i++)
        {
            for (int j = 0; j < recipe.elements.Count; j++)
            {
                //if (container.slots[i].item == recipe.elements[0].item)
                //{
                //    container.slots[i].itemCount -= recipe.elements[0].itemCount;
                //}

                //if (container.slots[i].item == recipe.elements[1].item)
                //{
                //    container.slots[i].itemCount -= recipe.elements[1].itemCount;
                //}

                if (container.slots[i].item == recipe.elements[j].item)
                {
                    container.slots[i].itemCount -= recipe.elements[j].itemCount;
                }
            }
        }

        GameManager.instance.inventoryContainer.AddItem(item, 1);
    }


    public void CraftAxe(/*Image img*/)
    {
        //GameManager.instance.hasAxe = true;

        if (isAxe)
        {
            if (GameManager.instance.hasAxe == false)
            {
                //toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasAxe = true;
                craftBttn.gameObject.SetActive(false);
            }
            else
            {
                //craftBttn.interactable = false;
                craftBttn.gameObject.SetActive(false);
            }
        }



    }

    public void CraftCampsite()
    {
        //GameManager.instance.hasCampsite = true;
        if (isCampsite)
        {
            if (GameManager.instance.hasCampsite == false)
            {
                //toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasCampsite = true;
                craftBttn.gameObject.SetActive(false);
            }
            else
            {
                //craftBttn.interactable = false;
                craftBttn.gameObject.SetActive(false);
            }
        }
    }

    public void CraftKnife()
    {
        //GameManager.instance.hasKnife = true;
        if (isKnife)
        {
            if (GameManager.instance.hasKnife == false)
            {
                //toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasKnife = true;
                craftBttn.gameObject.SetActive(false);
            }
            else
            {
                //craftBttn.interactable = false;
                craftBttn.gameObject.SetActive(false);
            }
        }
    }

    public void CraftSpear()
    {
        //GameManager.instance.hasLance = true;
        if (isLance)
        {
            if (GameManager.instance.hasLance == false)
            {
                //toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasLance = true;
                craftBttn.gameObject.SetActive(false);
            }
            else
            {
                //craftBttn.interactable = false;
                craftBttn.gameObject.SetActive(false);
            }
        }
    }

    public void CraftFishingRod()
    {
        //GameManager.instance.hasFishingRod = true;
        if (isFishingRod)
        {
            if (GameManager.instance.hasFishingRod == false)
            {
                //toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasFishingRod = true;
                craftBttn.gameObject.SetActive(false);
            }
            else
            {
                //craftBttn.interactable = false;
                craftBttn.gameObject.SetActive(false);
            }
        }
    }

    public void CraftTorch()
    {
        //GameManager.instance.hasTorch = true;
        if (isTorch)
        {
            if (GameManager.instance.hasTorch == false)
            {
                //toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasTorch = true;
                craftBttn.gameObject.SetActive(false);
            }
            else
            {
                //craftBttn.interactable = false;
                craftBttn.gameObject.SetActive(false);
            }
        }
    }
}
