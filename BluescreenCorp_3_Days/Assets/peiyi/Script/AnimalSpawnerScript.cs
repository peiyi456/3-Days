using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawnerScript : MonoBehaviour
{
    public GameObject[] animal;
    public float[] minX, maxX, minY, maxY;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public static int[] animalNo;

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
    }
}
