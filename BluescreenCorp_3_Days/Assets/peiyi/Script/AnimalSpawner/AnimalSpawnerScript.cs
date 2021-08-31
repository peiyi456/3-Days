﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawnerScript : MonoBehaviour
{
    public GameObject animal;
    public float minX, maxX, minY, maxY;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    //public static int[] animalNo = new int[] { 0, 0, 0};
    public int No = 0;

    public Transform WanderingArea;
    public float Radius;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(Time.time > nextSpawn)
        //{
        //    for (int i = 0; i < animal.Length; i++)
        //    {
        //        if (animalNo[i] < 3)
        //        {
        //            nextSpawn = Time.time + spawnRate;
        //            randX = Random.Range(minX[i], maxX[i]);
        //            randY = Random.Range(minY[i], maxY[i]);
        //            whereToSpawn = new Vector2(randX, randY);
        //            Instantiate(animal[i], whereToSpawn, Quaternion.identity);
        //            animalNo[i]++;
        //        }
        //    }
        //}

        //Debug.Log(animalNo);
        if (GameManager.instance.isPause == false)
        {
            if (Time.time > nextSpawn)
            {


                if (No < 3)
                {
                    Vector2 randomInCircle = new Vector2(WanderingArea.position.x, WanderingArea.position.y) + Random.insideUnitCircle * Radius;
                    //Vector3 Destination = new Vector3(randomInCiecle.x, randomInCiecle.y, 0f);
                    nextSpawn = Time.time + spawnRate;
                    //randX = Random.Range(minX, maxX);
                    //randY = Random.Range(minY, maxY);
                    //whereToSpawn = new Vector2(randX, randY);
                    GameObject spawnAnimal = Instantiate(animal, randomInCircle, Quaternion.identity) as GameObject;
                    spawnAnimal.transform.SetParent(this.transform, false);
                    
                    No++;
                }



            }
        }
    }
}
