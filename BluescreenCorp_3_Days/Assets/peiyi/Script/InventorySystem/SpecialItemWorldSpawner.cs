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
            item = GameManager.instance.thisAnimal.DropItem;
            ItemSpawnManager.instance.SpawnItem(new Vector3(GameManager.instance.enemyDropPosition.x, GameManager.instance.enemyDropPosition.y, GameManager.instance.zPositionForPickUp), item, itemCountInOneDrop);
            GameManager.instance.enemyFainted = false;
            //pickUpDrop.SetActive(true);
            //dropMeat.SetActive(true);
            //ItemWorld.SpawnItemWorld(BattleScene.position.position, item);
            //ItemSpawnManager.instance.SpawnItem(GameManager.instance.specialItemDropPos, item, itemCountInOneDrop);
            //BattleSystem.isDrop = false;
            //GameManager.instance.isPause = true;
        }
    }
}
