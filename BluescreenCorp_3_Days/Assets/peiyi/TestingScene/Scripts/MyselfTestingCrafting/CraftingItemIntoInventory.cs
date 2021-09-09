using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingItemIntoInventory : MonoBehaviour
{
    [SerializeField] bool canCraft = false;
    [SerializeField] bool hasElement1, hasElement2, hasElement3;
    [SerializeField] Image element1, element2, element3, output;
    public Button craftBttn;

    [SerializeField] CraftingItemRecipe recipe;
    [SerializeField] ItemContainer container;

    public bool selected = false;
    [SerializeField] Button bttn1, bttn2;
    //public ItemSlot itemSlot;
    //public ItemSlot itemSlot2;

    // Start is called before the first frame update
    void Start()
    {
        //element1.sprite = recipe.elements[0].item.icon;
        //element1.color = Color.black;

        //if(recipe.elements.Count > 1)
        //{
        //    element2.sprite = recipe.elements[1].item.icon;
        //    element2.color = Color.black;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanCraft(container);
        CanCraft();
        ButtonInteractable();
    }

    public void IfSelec()
    {
        selected = !selected;

        element1.gameObject.SetActive(selected);
        element2.gameObject.SetActive(selected);
        element3.gameObject.SetActive(selected);
        output.gameObject.SetActive(selected);
        craftBttn.gameObject.SetActive(selected);
        element1.sprite = recipe.elements[0].item.icon;
        output.sprite = recipe.output.item.icon;

        if(recipe.elements.Count > 1)
        {
            element2.sprite = recipe.elements[1].item.icon;
        }
    }

    public void OffSelect(Button bttn)
    {
        bttn.GetComponent<CraftingItemIntoInventory>().selected = false;
    }

    void CheckCanCraft(ItemContainer container)
    {
        ItemSlot itemSlot = container.slots.Find(x => x.item == recipe.elements[0].item);

        if (itemSlot != null)
        {
            if (itemSlot.itemCount >= recipe.elements[0].itemCount)
            {
                hasElement1 = true;
            }
            else
            {
                hasElement1 = false;
            }
        }

        else
        {
            hasElement1 = false;
        }

        if (recipe.elements.Count > 1)
        {
            ItemSlot itemSlot2 = container.slots.Find(x => x.item == recipe.elements[1].item);

            if (itemSlot2 != null)
            {
                if (itemSlot2.itemCount >= recipe.elements[1].itemCount)
                {
                    hasElement2 = true;
                }
                else
                {
                    hasElement2 = false;
                }
            }

            else
            {
                hasElement2 = false;
            }
        }

        //for(int i = 0; i < container.slots.Count; i++)
        //{
        //    if(container.slots[i].item == recipe.elements[0].item)
        //    {
        //        if(container.slots[i].itemCount >= recipe.elements[0].itemCount)
        //        {
        //            hasElement1 = true;
        //            Debug.Log("Has element 1");
        //        }

        //        else
        //        {
        //            Debug.Log("Run here");
        //            hasElement1 = false;
        //        }
        //    }

        //    if(recipe.elements.Count > 1)
        //    {
        //        if (container.slots[i].item == recipe.elements[1].item)
        //        {
        //            if (container.slots[i].itemCount >= recipe.elements[1].itemCount)
        //            {
        //                hasElement2 = true;
        //            }

        //            else
        //            {
        //                hasElement2 = false;
        //            }
        //        }
        //    }
        //}

        //if (recipe.elements.Count > 1)
        //{
        //    itemSlot2 = GameManager.instance.inventoryContainer.slots.Find(x => x.item == recipe.elements[1].item);
        //}
        //Debug.Log(itemSlot);
        ////Debug.Log(itemSlot2);
        //if (recipe.elements.Count == 1)
        //{
        //    if (itemSlot != null)
        //    {
        //        if (itemSlot.itemCount >= recipe.elements[0].itemCount)
        //        {
        //            hasElement1 = true;
        //        }
        //    }
        //}

        //else if(recipe.elements.Count > 1)
        //{
        //    if (itemSlot != null)
        //    {
        //        if (itemSlot.itemCount >= recipe.elements[0].itemCount)
        //        {
        //            hasElement1 = true;
        //        }
        //    }

        //    if (itemSlot2 != null)
        //    {
        //        if (itemSlot2.itemCount >= recipe.elements[1].itemCount)
        //        {
        //            hasElement2 = true;
        //        }
        //    }
        //}

        //for (int i = 0; i < GameManager.instance.inventoryContainer.slots.Count; i++)
        //{
        //    if (GameManager.instance.inventoryContainer.slots[i].item == recipe.elements[0].item)
        //    {
        //        if (GameManager.instance.inventoryContainer.slots[i].itemCount >= recipe.elements[0].itemCount)
        //        {
        //            hasElement1 = true;
        //            //element1.color = Color.white;
        //        }
        //        else
        //        {
        //            hasElement1 = false;
        //        }
        //    }

        //    if (recipe.elements.Count > 1)
        //    {
        //        if (GameManager.instance.inventoryContainer.slots[i].item == recipe.elements[1].item)
        //        {
        //            if (GameManager.instance.inventoryContainer.slots[i].itemCount >= recipe.elements[1].itemCount)
        //            {
        //                hasElement2 = true;
        //            }

        //            else
        //            {
        //                hasElement2 = false;
        //            }
        //        }
        //    }

        //}

        //if (recipe.elements.Count < 2)
        //{
        //    if (hasElement1 == true)
        //    {
        //        if (!craft)
        //        {
        //            craftBttn.interactable = true;
        //            //checkingButtonInteractable();
        //            //output.color = Color.white;
        //            this.craft = true;
        //        }
        //    }

        //    else
        //    {
        //        //craftBttn.interactable = false;
        //        //output.color = Color.black;
        //    }
        //}

        //else if (recipe.elements.Count < 3)
        //{
        //    if (hasElement1 == true && hasElement2 == true)
        //    {
        //        if (!craft)
        //        {
        //            //checkingButtonInteractable();
        //            craftBttn.interactable = true;
        //            //output.color = Color.white;
        //            this.craft = true;
        //        }
        //    }

        //    else
        //    {
        //        //craftBttn.interactable = false;
        //        //output.color = Color.black;
        //    }
        //}
        //else
        //{
        //    if (hasElement1 == true && hasElement2 == true && hasElement3 == true)
        //    {
        //        if (!craft)
        //        {
        //            //checkingButtonInteractable();
        //            craftBttn.interactable = true;
        //            //output.color = Color.white;
        //            this.craft = true;
        //        }
        //    }

        //    else
        //    {
        //        //craftBttn.interactable = false;
        //        //output.color = Color.black;
        //    }

        //}
    }

    void CanCraft()
    {
        if(recipe.elements.Count == 1)
        {
            if(hasElement1)
            {
                element1.color = Color.white;
            }
            else
            {
                element1.color = Color.black;
            }
        }

        else if(recipe.elements.Count > 1)
        {
            if(hasElement1)
            {
                element1.color = Color.white;
            }
            else
            {
                element1.color = Color.black;
            }

            if(hasElement2)
            {
                element2.color = Color.white;
            }
            else
            {
                element1.color = Color.black;
            }
        }
    }

    void ButtonInteractable()
    {
        if (selected)
        {
            craftBttn.gameObject.SetActive(true);
            if (recipe.elements.Count == 1)
            {
                if (hasElement1)
                {
                    //element1.color = Color.white;
                    craftBttn.interactable = true;
                    canCraft = true;
                }

                else
                {
                    craftBttn.interactable = false;
                    canCraft = false;
                }
            }

            else if (recipe.elements.Count > 1)
            {
                if (hasElement1 && hasElement2)
                {
                    //craftBttn.gameObject.SetActive(true);
                    craftBttn.interactable = true;
                    canCraft = true;
                }

                else
                {
                    craftBttn.interactable = false;
                    canCraft = false;
                }
            }
        }

        else
        {
            craftBttn.gameObject.SetActive(false);

        }
    }

    public void ButtonFunction()
    {
        if (canCraft)
        {
            container.RemoveItem(recipe.elements[0].item, recipe.elements[0].itemCount);

            if (recipe.elements.Count > 1)
            {
                container.RemoveItem(recipe.elements[1].item, recipe.elements[1].itemCount);
            }
            container.AddItem(recipe.output.item, 1);
            StartCoroutine(CDTimeForCraft());
        }
    }

    IEnumerator CDTimeForCraft()
    {
        craftBttn.interactable = false;
        yield return new WaitForSeconds(1f);
        if(canCraft == true)
        {
            craftBttn.interactable = true;
        }
        
    }
}
