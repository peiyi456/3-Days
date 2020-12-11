using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssets_ : MonoBehaviour
{
    public static ItemAssets_ Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite axeSprite;
    public Sprite campingSiteSprite;
    public Sprite bluntKnifeSprite;
    public Sprite spearSprite;
    public Sprite stoneSprite;
    public Sprite meatSprite;
    public Sprite bananaSprite;
    public Sprite leaveSprite;
    public Sprite mangoSprite;
    public Sprite logSprite;

    public string axeName;
    public string campingSiteName;
    public string bluntKnifeName;
    public string spearName;
    public string stoneName;
    public string meatName;
    public string bananaName;
    public string leaveName;
    public string mangoName;
    public string logName; 

    [TextArea] public string axeFunc;
    [TextArea] public string campingSiteFunc;
    [TextArea] public string bluntKnifeFunc;
    [TextArea] public string spearFunc;
    [TextArea] public string stoneFunc;
    [TextArea] public string meatFunc;
    [TextArea] public string bananaFunc;
    [TextArea] public string leave;
    [TextArea] public string mangoFunc;
    [TextArea] public string logFunc;

    [TextArea] public string axeHints;
    [TextArea] public string campingSiteHints;
    [TextArea] public string bluntKnifeHints;
    [TextArea] public string spearHints;
    [TextArea] public string stoneSkinHints;
    [TextArea] public string meatHints;
    [TextArea] public string bananaHints;
    [TextArea] public string leaveHints;
    [TextArea] public string mangoHints;
    [TextArea] public string logHints;

    public Button axeButton;
    public Button toolsButton;
    public Button woodswordButton;
}
