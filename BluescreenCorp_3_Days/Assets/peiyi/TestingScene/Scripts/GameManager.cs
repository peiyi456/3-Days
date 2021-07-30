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

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemDragAndDropController itemDragAndDropController;
    public bool hasAxe, hasCampsite, hasKnife, hasSpear;
    public bool isPause;
    public bool isBattle;
    public Vector2 specialItemDropPos;
    public AnimalBase thisAnimal;

    public bool isPutCamp1, isPutCamp2;

    public bool Objective1, Objective2, Objective3;
}
