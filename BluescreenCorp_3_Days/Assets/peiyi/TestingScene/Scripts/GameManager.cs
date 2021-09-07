﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("Sound Manager")]
    public AudioSource soundEffect;
    public AudioSource BGM;

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
    public bool hasLance;
    public bool hasFishingRod;
    public bool hasTorch;

    [Header("Animal Checking")]
    public bool[] meetAnimal;
    public _UnitsBase[] Animals;

    [Header("Game Controller")]
    public bool isPause;
    public GameObject TextReminder;
    public bool isNight;

    [Header("Battle and Drop Item")]
    public bool isBattle;
    public Vector3 enemyDropPosition;
    public _UnitsBase thisAnimal;
    public bool enemyFainted;

    [Header("Tools using checking")]
    public bool isPutCamp1;
    public bool isPutCamp2;

    [Header("Checking objectives")]
    public bool Objective1;
    public bool Objective2;
    public bool Objective3;

    [Header("Pick up item's z position")]
    public float zPositionForPickUp;
}
