using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItemAsset_ : MonoBehaviour
{
    public static CraftItemAsset_ Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //public Transform pfItemWorld;

    public Sprite axeSprite;
    public Sprite campingSiteSprite;
    public Sprite bluntKnifeSprite;
    public Sprite spearSprite;

    public string axeName;
    public string campingSiteName;
    public string bluntKnifeName;
    public string spearName;

    [TextArea] public string axeFunc;
    [TextArea] public string campingSiteFunc;
    [TextArea] public string bluntKnifeFunc;
    [TextArea] public string spearFunc;

    [TextArea] public string axeHints;
    [TextArea] public string campingSiteHints;
    [TextArea] public string bluntKnifeHints;
    [TextArea] public string spearHints;

}
