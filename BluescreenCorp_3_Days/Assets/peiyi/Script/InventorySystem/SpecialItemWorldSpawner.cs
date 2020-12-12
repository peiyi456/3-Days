using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemWorldSpawner : MonoBehaviour
{
    public Item_ item;
    public GameObject dropMeat;
    public GameObject pfItem;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(BattleSystem.isDrop == true)
        {
            //dropMeat.SetActive(true);
            ItemWorld.SpawnItemWorld(this.transform.position, item);
            BattleSystem.isDrop = false;
        }
    }
}
