using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item_
{
    public enum ItemType_

    {
        Axe,
        CampingSite,
        BluntKnife,
        Spear,
        Banana ,
        Mango,
        Meat,
        Log,
        Leave,
        Stone,
    }

    public ItemType_ itemType_;
    public int amount_;
    public int maxSlotAmount_;

    public Sprite GetSprite()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeSprite;

            case ItemType_.CampingSite: return ItemAssets_.Instance.campingSiteSprite;

            case ItemType_.BluntKnife: return ItemAssets_.Instance.bluntKnifeSprite;

            case ItemType_.Spear: return ItemAssets_.Instance.spearSprite;

            case ItemType_.Stone: return ItemAssets_.Instance.stoneSprite;

            case ItemType_.Banana: return ItemAssets_.Instance.bananaSprite;

            case ItemType_.Leave: return ItemAssets_.Instance.leaveSprite;

            case ItemType_.Mango: return ItemAssets_.Instance.mangoSprite;

            case ItemType_.Log: return ItemAssets_.Instance.logSprite;

            case ItemType_.Meat: return ItemAssets_.Instance.meatSprite;
        }
    }

    public string GetItemName()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeName;

            case ItemType_.CampingSite: return ItemAssets_.Instance.campingSiteName;

            case ItemType_.BluntKnife: return ItemAssets_.Instance.bluntKnifeName;

            case ItemType_.Spear: return ItemAssets_.Instance.spearName;

            case ItemType_.Stone: return ItemAssets_.Instance.stoneName;

            case ItemType_.Banana: return ItemAssets_.Instance.bananaName;

            case ItemType_.Leave: return ItemAssets_.Instance.leaveName;

            case ItemType_.Mango: return ItemAssets_.Instance.mangoName;

            case ItemType_.Log: return ItemAssets_.Instance.logName;

            case ItemType_.Meat: return ItemAssets_.Instance.meatName;

        }
    }

    public string GetItemFunc()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeFunc;

            case ItemType_.CampingSite: return ItemAssets_.Instance.campingSiteFunc;

            case ItemType_.BluntKnife: return ItemAssets_.Instance.bluntKnifeFunc;

            case ItemType_.Spear: return ItemAssets_.Instance.spearFunc;

            case ItemType_.Stone: return ItemAssets_.Instance.stoneFunc;

            case ItemType_.Banana: return ItemAssets_.Instance.bananaFunc;

            case ItemType_.Leave: return ItemAssets_.Instance.leave;

            case ItemType_.Mango: return ItemAssets_.Instance.mangoFunc;

            case ItemType_.Log: return ItemAssets_.Instance.logFunc;

            case ItemType_.Meat: return ItemAssets_.Instance.meatFunc;

        }
    }

    public string GetItemHints()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeHints;

            case ItemType_.CampingSite: return ItemAssets_.Instance.campingSiteHints;

            case ItemType_.BluntKnife: return ItemAssets_.Instance.bluntKnifeHints;

            case ItemType_.Spear: return ItemAssets_.Instance.spearHints;

            case ItemType_.Stone: return ItemAssets_.Instance.stoneSkinHints;

            case ItemType_.Banana: return ItemAssets_.Instance.bananaHints;

            case ItemType_.Leave: return ItemAssets_.Instance.leaveHints;

            case ItemType_.Mango: return ItemAssets_.Instance.mangoHints;

            case ItemType_.Log: return ItemAssets_.Instance.logHints;

            case ItemType_.Meat: return ItemAssets_.Instance.meatHints;

        }
    }

    //public Button GetButtonOn()
    //{
    //    switch (itemType_)
    //    {
    //        default:
    //        case ItemType_.Axe: return ItemAssets_.Instance.axeButton;

    //        case ItemType_.Tools: return ItemAssets_.Instance.toolsButton;

    //        case ItemType_.Woodsword: return ItemAssets_.Instance.woodswordHints;

    //    }
    //}

    public bool IsStackable()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe:
            case ItemType_.CampingSite:
            case ItemType_.BluntKnife:
            case ItemType_.Spear:
            case ItemType_.Banana:
            case ItemType_.Leave:
            case ItemType_.Log:
            case ItemType_.Mango:
            case ItemType_.Meat:
            case ItemType_.Stone:
                return true;
        }
    }

    public bool IsUsable()
    {
        switch(itemType_)
        {
            default:
            
            //case ItemType_.Woodsword:
            case ItemType_.Banana:
            case ItemType_.Mango:
            case ItemType_.Meat:
                return true;

            case ItemType_.BluntKnife:
            case ItemType_.Axe:
            case ItemType_.CampingSite:
            case ItemType_.Spear:
            case ItemType_.Leave:
            case ItemType_.Log:
            case ItemType_.Stone:
                return false;
        }
    }

    public bool IsCraftableResources()
    {
        switch (itemType_)
        {
            default:

            //case ItemType_.Woodsword:
            case ItemType_.Banana:
            case ItemType_.Mango:
            case ItemType_.Meat:
            case ItemType_.BluntKnife:
            case ItemType_.Axe:
            case ItemType_.CampingSite:
            case ItemType_.Spear:
                return false;

            case ItemType_.Leave:
            case ItemType_.Log:
            case ItemType_.Stone:
                return true;
        }
    }

    //public bool IsCeaftableTools()
    //{
    //    switch (itemType_)
    //    {
    //        default:

    //        //case ItemType_.Woodsword:
    //        case ItemType_.Banana:
    //        case ItemType_.Mango:
    //        case ItemType_.Meat:
    //        case ItemType_.Feather:
    //        case ItemType_.Log:
    //        case ItemType_.AnimalSkin:
    //            return false;

    //        case ItemType_.Woodsword:
    //        case ItemType_.Axe:
    //        case ItemType_.Tools:
    //            return true;
    //    }
    //}

}
