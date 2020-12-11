using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets_ : MonoBehaviour
{
    public static ItemAssets_ Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite axeSprite;
    public Sprite toolsSprite;
    public Sprite woodswordSprite;

    public string axeName;
    public string toolsName;
    public string woodswordName;

    [TextArea] public string axeFunc;
    [TextArea] public string toolsFunc;
    [TextArea] public string woodswordFunc;

    [TextArea] public string axeHints;
    [TextArea] public string toolsHints;
    [TextArea] public string woodswordHints;
}
