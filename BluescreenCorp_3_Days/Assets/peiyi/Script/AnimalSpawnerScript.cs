using System.Collections;
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
    public static int animalNo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            if (animalNo < 3)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(minX, maxX);
                randY = Random.Range(minY, maxY);
                whereToSpawn = new Vector2(randX, randY);
                Instantiate(animal, whereToSpawn, Quaternion.identity);
                animalNo++;
            }
        }

        //Debug.Log(animalNo);
    }
}
