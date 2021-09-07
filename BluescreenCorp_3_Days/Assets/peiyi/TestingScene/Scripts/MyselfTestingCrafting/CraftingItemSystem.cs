using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingItemSystem : MonoBehaviour
{
    [Header("For shortkey tools used")]
    [SerializeField] bool isAxe, isCampsite, isKnife, isSpear, isFishingRod, isTorch;

    [SerializeField] bool craft = false;
    [SerializeField] bool hasElement1, hasElement2, hasElement3;
    [SerializeField] Image element1, element2, element3, output;
    [SerializeField] Button craftBttn;
    [SerializeField] int CraftItemBttnNo;
    [SerializeField] CraftingItemRecipe recipe;
    [SerializeField] ItemContainer container;

    [SerializeField] bool selected = false;

    [SerializeField] Image/*[]*/ toolsButtonShortKeyImage;

    private void Update()
    {
        CanCraft(container);
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
                    output.color = Color.white;
                    this.craft = true;
                }
            }

            else
            {
                //craftBttn.interactable = false;
                output.color = Color.black;
            }
        }

        else if (recipe.elements.Count < 3)
        {
            if (hasElement1 == true && hasElement2 == true)
            {
                if (!craft)
                {
                    craftBttn.interactable = true;
                    output.color = Color.white;
                    this.craft = true;
                }
            }

            else
            {
                //craftBttn.interactable = false;
                output.color = Color.black;
            }
        }
        else
        {
            if (hasElement1 == true && hasElement2 == true && hasElement3 == true)
            {
                if (!craft)
                {
                    craftBttn.interactable = true;
                    output.color = Color.white;
                    this.craft = true;
                }
            }

            else
            {
                //craftBttn.interactable = false;
                output.color = Color.black;
            }

        }
    }

    public void ButtonClicked()
    {
        //CraftItemBttnNo = ButtonNo;
        if(!selected)
        {
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
        }
        else
        {
            element1.gameObject.SetActive(false);
            element2.gameObject.SetActive(false);
            element3.gameObject.SetActive(false);
            output.gameObject.SetActive(false);
            craftBttn.gameObject.SetActive(false);
            selected = false;
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
        if (isAxe)
        {
            if (GameManager.instance.hasAxe == false)
            {
                toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasAxe = true;
            }
            else
            {
                craftBttn.interactable = false;
            }
        }
        //if (isAxe)
        //{
        //    if (GameManager.instance.hasAxe == false)
        //    {
        //        toolsButtonShortKeyImage.color = Color.white;
        //        GameManager.instance.hasAxe = true;

        //        for (int i = 0; i < container.slots.Count; i++)
        //        {
        //            if (container.slots[i].item == recipe.elements[0].item)
        //            {
        //                container.slots[i].itemCount -= recipe.elements[0].itemCount;
        //            }

        //            if (container.slots[i].item == recipe.elements[1].item)
        //            {
        //                container.slots[i].itemCount -= recipe.elements[1].itemCount;
        //            }

        //            if (recipe.elements.Count > 2)
        //            {
        //                if (container.slots[i].item == recipe.elements[2].item)
        //                {
        //                    container.slots[i].itemCount -= recipe.elements[2].itemCount;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        craftBttn.interactable = false;
        //    }
        //}
        //else if (isCampsite)
        //{
        //    if (GameManager.instance.hasCampsite == false)
        //    {
        //        toolsButtonShortKeyImage[1].color = Color.white;
        //        GameManager.instance.hasCampsite = true;
        //    }
        //    else
        //    {
        //        craftBttn.interactable = false;
        //    }
        //}
        //else if (isKnife)
        //{
        //    if (GameManager.instance.hasKnife == false)
        //    {
        //        toolsButtonShortKeyImage[2].color = Color.white;
        //        GameManager.instance.hasKnife = true;
        //    }
        //    else
        //    {
        //        craftBttn.interactable = false;
        //    }
        //}
        //else if (isSpear)
        //{
        //    if (GameManager.instance.hasSpear == false)
        //    {
        //        toolsButtonShortKeyImage[3].color = Color.white;
        //        GameManager.instance.hasSpear = true;
        //    }
        //    else
        //    {
        //        craftBttn.interactable = false;
        //    }
        //}

    }

    public void CraftCampsite()
    {
        if (isCampsite)
        {
            if (GameManager.instance.hasCampsite == false)
            {
                toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasCampsite = true;
            }
            else
            {
                craftBttn.interactable = false;
            }
        }
    }

    public void CraftKnife()
    {
        if (isKnife)
        {
            if (GameManager.instance.hasKnife == false)
            {
                toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasKnife = true;
            }
            else
            {
                craftBttn.interactable = false;
            }
        }
    }

    public void CraftSpear()
    {
        if (isSpear)
        {
            if (GameManager.instance.hasLance == false)
            {
                toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasLance = true;
            }
            else
            {
                craftBttn.interactable = false;
            }
        }
    }

    public void CraftFishingRod()
    {
        if (isFishingRod)
        {
            if (GameManager.instance.hasFishingRod == false)
            {
                toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasFishingRod = true;
            }
            else
            {
                craftBttn.interactable = false;
            }
        }
    }

    public void CraftTorch()
    {
        if (isTorch)
        {
            if (GameManager.instance.hasTorch == false)
            {
                toolsButtonShortKeyImage.color = Color.white;
                GameManager.instance.hasTorch = true;
            }
            else
            {
                craftBttn.interactable = false;
            }
        }
    }
}
