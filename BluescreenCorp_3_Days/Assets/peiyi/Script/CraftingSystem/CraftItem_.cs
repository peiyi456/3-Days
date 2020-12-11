using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CraftItem_
{
    public enum CraftItemType_

    {
        Axe,
        CampingSite,
        BluntKnife,
        Spear,

    }

    public CraftItemType_ craftItemType_;
    public int craftItemAmount_;

    public Sprite GetCraftItemSprite()
    {
        switch (craftItemType_)
        {
            default:
            case CraftItemType_.Axe: return         CraftItemAsset_.Instance.axeSprite;
                                                    
            case CraftItemType_.CampingSite: return CraftItemAsset_.Instance.campingSiteSprite;
                                                    
            case CraftItemType_.BluntKnife: return  CraftItemAsset_.Instance.bluntKnifeSprite;
                                                    
            case CraftItemType_.Spear: return       CraftItemAsset_.Instance.spearSprite;


        }
    }

    public string GetCraftItemName()
    {
        switch (craftItemType_)
        {
            default:
            case CraftItemType_.Axe: return CraftItemAsset_.Instance.axeName;

            case CraftItemType_.CampingSite: return CraftItemAsset_.Instance.campingSiteName;

            case CraftItemType_.BluntKnife: return CraftItemAsset_.Instance.bluntKnifeName;

            case CraftItemType_.Spear: return CraftItemAsset_.Instance.spearName;

        }
    }

    public string GetCraftItemFunc()
    {
        switch (craftItemType_)
        {
            default:
            case CraftItemType_.Axe: return CraftItemAsset_.Instance.axeFunc;

            case CraftItemType_.CampingSite: return CraftItemAsset_.Instance.campingSiteFunc;

            case CraftItemType_.BluntKnife: return CraftItemAsset_.Instance.bluntKnifeFunc;

            case CraftItemType_.Spear: return CraftItemAsset_.Instance.spearFunc;

        }
    }

    public string GetCraftItemHints()
    {
        switch (craftItemType_)
        {
            default:
            case CraftItemType_.Axe: return CraftItemAsset_.Instance.axeHints;

            case CraftItemType_.CampingSite: return CraftItemAsset_.Instance.campingSiteHints;

            case CraftItemType_.BluntKnife: return CraftItemAsset_.Instance.bluntKnifeHints;

            case CraftItemType_.Spear: return CraftItemAsset_.Instance.spearHints;


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

    //public bool IsStackable()
    //{
    //    switch (craftItemType_)
    //    {
    //        default:
    //        case CraftItemType_.Axe:
    //        case CraftItemType_.CampingSite:
    //        case CraftItemType_.BluntKnife:
    //        case CraftItemType_.Spear:

    //            return true;
    //    }
    //}

    //public bool IsUsable()
    //{
    //    switch (craftItemType_)
    //    {
    //        default:

            

    //        //case ItemType_.BluntKnife:
    //        //case ItemType_.Axe:
    //        //case ItemType_.CampingSite:
            
    //            return false;
    //    }
    //}

    //public bool IsCraftableResources()
    //{
    //    switch (craftItemType_)
    //    {
    //        default:

    //        //case ItemType_.Woodsword:

    //            //case ItemType_.BluntKnife:
    //            //case ItemType_.Axe:
    //            //case ItemType_.CampingSite:
    //    //        return false;


    //    //        return true;
    //    //}
    //}

    public bool IsCeaftableTools()
    {
        switch (craftItemType_)
        {
            default:
            case CraftItemType_.Axe:
            case CraftItemType_.CampingSite:
            case CraftItemType_.BluntKnife:
            case CraftItemType_.Spear:
                return true;
        }
    }
}
