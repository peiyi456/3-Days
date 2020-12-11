using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingNeeded : MonoBehaviour
{
    public event EventHandler OnItemListChanged;
    private Inventory_ inventory_;
    private List<Item_> itemList_;
    private Item_ item;

    public Image ItemA;
    public Image ItemB;
    public Image CraftingResult;
    public Image DisplayImage;
    public Sprite logSprite;
    public Sprite stoneSprite;
    public Sprite leavesSprite;
    public Sprite bluntKnifeSprite;
    public Sprite axeSprite;
    public Sprite campsiteSprite;
    public Sprite spearSprite;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    [SerializeField] bool isAxe;
    [SerializeField] bool isCampingSite;
    [SerializeField] bool isBluntKnife;
    [SerializeField] bool isSpear;

    [SerializeField] bool hasAxe;
    [SerializeField] bool hasCampingSite;
    [SerializeField] bool hasBluntKnife;
    [SerializeField] bool hasSpear;

    public Button craftButton;

    int x; 
    int y;

    // Start is called before the first frame update
    void Start()
    {
        //CraftingResult.sprite = DisplayImage.sprite;

        //isAxe = false;
        //isCampingSite = false;
        //isBluntKnife = false;
        //isSpear = false;

        hasAxe = false;
        hasCampingSite = false;
        hasBluntKnife = false;
        hasSpear = false;

        //craftButton.onClick.AddListener(CreateItem);
    }

    // Update is called once per frame
    void Update()
    {
        CheckingCraftingItem();
        CheckingWhichCraftBeenSelected(item);
        CreateItem();
    }

    void CheckingCraftingItem()
    {
        if (hasAxe)
        {
            DisplayImage.color = new Color(255f, 255f, 255f);
        }

        else if (hasCampingSite)
        {
            DisplayImage.color = new Color(255f, 255f, 255f);
        }

        else if (hasBluntKnife)
        {
            DisplayImage.color = new Color(255f, 255f, 255f);
        }

        else if (hasSpear)
        {
            DisplayImage.color = new Color(255f, 255f, 255f);
        }
    }

    void CheckingWhichCraftBeenSelected(Item_ item_)
    {
        this.GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (isAxe)
            {
                ItemA.sprite = logSprite;
                ItemB.sprite = stoneSprite;
                CraftingResult.sprite = axeSprite;
            }

            else if (isCampingSite)
            {
                ItemA.sprite = logSprite;
                ItemB.sprite = leavesSprite;
                CraftingResult.sprite = campsiteSprite;
            }

            else if (isBluntKnife)
            {
                ItemA.sprite = stoneSprite;
                //ItemB.sprite = leavesSprite;
                CraftingResult.sprite = bluntKnifeSprite;
            }

            else if (isSpear)
            {
                ItemA.sprite = bluntKnifeSprite;
                ItemB.sprite = logSprite;
                CraftingResult.sprite = spearSprite;
            }
        };
    }

    //public void SetInventory(Inventory_ inventory)
    //{
    //    this.inventory_ = inventory;

    //    //inventory.OnItemListChanged += Inventory_OnItemListChanged
    //}

    public void CreateItem(/*int x, int y, Item_ item_, CraftItem_ craftItem_*/)
    {
        if (CraftingResult.sprite == axeSprite)
        {
            Debug.Log("Hi");

            //if(item_.)

            //if (isAxe)
            //{
            //int a;
            //for (int i = 0; i < itemList_.Count; i++)
            //{
            //    if (itemList_[i].itemType_ == Item_.ItemType_.Log)
            //    {
            //        x = itemList_[i].amount_;
            //    }
            //    break;
            //}

            //for (int j = 0; j < itemList_.Count; j++)
            //{
            //    if (itemList_[j].itemType_ == Item_.ItemType_.Stone)
            //    {
            //        y = itemList_[j].amount_;
            //    }
            //    break;
            //}

            //x = itemList_[3].amount_;
            

                //if (x >= 1 && y >= 2)
                //{
                //    craftButton.interactable = true;
                //    Debug.Log("success");
                //}

                //else
                //{
                //    craftButton.interactable = false;
                //    Debug.Log("Failed");
                //}
                ////}

                //Debug.Log(x);
                //Debug.Log(y);
            //}
        }

    }
}
