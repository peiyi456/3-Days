using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemWorldSpawner : MonoBehaviour
{
    //public Item_ item;
    //public GameObject dropMeat;
    //public GameObject pfItem;
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] Item item;
    [SerializeField] int itemCountInOneDrop = 1;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(GameManager.instance.enemyFainted == true)
        {
            //pickUpDrop.SetActive(true);
            //dropMeat.SetActive(true);
            //ItemWorld.SpawnItemWorld(BattleScene.position.position, item);
            //ItemSpawnManager.instance.SpawnItem(GameManager.instance.specialItemDropPos, item, itemCountInOneDrop);
            //BattleSystem.isDrop = false;
            //GameManager.instance.isPause = true;
        }
    }
}
