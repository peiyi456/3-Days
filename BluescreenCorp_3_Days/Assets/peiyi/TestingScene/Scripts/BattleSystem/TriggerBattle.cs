﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattle : MonoBehaviour
{
    public event Action onTriggerBattle;

    //public GameObject playerObj, animalObj;
    //Collider2D playerCol, animalCol;

    [SerializeField] List<string> animalTag;
    [SerializeField] List<_UnitsBase> units = new List<_UnitsBase>();

    //[SerializeField] bool intersecting = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach(_UnitsBase u in Resources.LoadAll("Units/Animals", typeof(_UnitsBase)))
        {
            Debug.Log("Prefab found: " + u.name);
            units.Add(u);
            animalTag.Add(u.name);
        }
        //if(playerObj != null)
        //{
        //    playerCol = playerObj.GetComponent<Collider2D>();
        //}
    }

    private void Update()
    {
        //Debug.Log(animalCol.gameObject.name);
        //CheckForTrigger();
    }

    // Update is called once per frame
    //public void HandleUpdate()
    //{
    //    if(intersecting)
    //    {
    //        onTriggerBattle();
    //    }
    //}

    //void CheckForTrigger()
    //{
    //    Debug.Log("1");
    //    if (animalObj != null)
    //    {
    //        //animalCol = animalObj.GetComponent<Collider2D>();
    //        if (playerCol.bounds.Intersects(animalCol.bounds))
    //        {
    //            Debug.Log("Bounds intersecting");
    //            //intersecting = true;
    //            //onTriggerBattle();
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < animalTag.Count; i++)
        {
            if (other.CompareTag(animalTag[i]))
            {
                //Debug.Log("3");
                //animalObj = other.gameObject;
                //animalCol = other;
                if (!GameManager.instance.enemyFainted)
                {
                    GameManager.instance.specialItemDropPos = other.transform.position;
                    GameManager.instance.thisAnimal = units[i];
                    onTriggerBattle();
                }
                else
                {
                    Destroy(other.gameObject);
                    GameManager.instance.enemyFainted = false;
                }
            }
        }
    }
}