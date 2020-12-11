using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item_
{
    public enum ItemType_

    {
        Axe,
        Tools,
        Woodsword,
    }

    public ItemType_ itemType_;
    public int amount_;

    public Sprite GetSprite()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeSprite;

            case ItemType_.Tools: return ItemAssets_.Instance.toolsSprite;

            case ItemType_.Woodsword: return ItemAssets_.Instance.woodswordSprite;
        }
    }

    public string GetItemName()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeName;

            case ItemType_.Tools: return ItemAssets_.Instance.toolsName;

            case ItemType_.Woodsword: return ItemAssets_.Instance.woodswordName;

        }
    }

    public string GetItemFunc()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeFunc;

            case ItemType_.Tools: return ItemAssets_.Instance.toolsFunc;

            case ItemType_.Woodsword: return ItemAssets_.Instance.woodswordFunc;

        }
    }

    public string GetItemHints()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe: return ItemAssets_.Instance.axeHints;

            case ItemType_.Tools: return ItemAssets_.Instance.toolsHints;

            case ItemType_.Woodsword: return ItemAssets_.Instance.woodswordHints;

        }
    }

    public bool IsStackable()
    {
        switch (itemType_)
        {
            default:
            case ItemType_.Axe:
            case ItemType_.Tools:
            case ItemType_.Woodsword:
                return true;
        }
    }
}
