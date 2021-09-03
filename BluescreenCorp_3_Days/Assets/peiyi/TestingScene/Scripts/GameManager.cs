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

    [Header("Animal Checking")]
    public bool meetAnimal1;
    public bool meetAnimal2;
    public bool meetAnimal3;

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
