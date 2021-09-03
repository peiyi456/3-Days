using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("Player")]
    public GameObject player;
    public GameObject playerLoadingBar;

    [Header("Inventory")]
    public ItemContainer inventoryContainer;
    public ItemDragAndDropController itemDragAndDropController;

    [Header("Tools checking")]
    public bool hasAxe;
    public bool hasCampsite;
    public bool hasKnife;
    public bool hasSpear;
    public bool hasFishingRod;

    [Header("Animal Checking")]
    public bool[] meetAnimal;
    public _UnitsBase[] Animals;

    [Header("Game Controller")]
    public bool isPause;

    [Header("Battle and Drop Item")]
    public bool isBattle;
    public Vector2 specialItemDropPos;
    public _UnitsBase thisAnimal;

    public bool enemyFainted;

    [Header("Tools using checking")]
    public bool isPutCamp1;
    public bool isPutCamp2;

    [Header("Checking objectives")]
    public bool Objective1;
    public bool Objective2;
    public bool Objective3;

}
