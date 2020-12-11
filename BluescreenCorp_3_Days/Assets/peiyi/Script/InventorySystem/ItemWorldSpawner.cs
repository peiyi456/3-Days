using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item_ item;

    private void Awake()
    {
        ItemWorld.SpawnItemWorld(this.transform.position, item);
        Destroy(gameObject);
    }
}
