using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawnerScript : MonoBehaviour
{
    public GameObject animal;
    //public float minX, maxX, minY, maxY;
    //float randX;
    //float randY;
    //Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    //public static int[] animalNo = new int[] { 0, 0, 0};
    public List<GameObject> AnimalList;
    public int No = 0;
    public int MaxNo;

    public Transform WanderingArea;
    public float Radius;
    public float seekingPlayerRadius;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {


            if (AnimalList.Count < MaxNo)
            {
                Vector2 randomInCircle = new Vector2(WanderingArea.position.x, WanderingArea.position.y) + Random.insideUnitCircle * Radius;
                //Vector3 Destination = new Vector3(randomInCiecle.x, randomInCiecle.y, 0f);
                nextSpawn = Time.time + spawnRate;
                //randX = Random.Range(minX, maxX);
                //randY = Random.Range(minY, maxY);
                //whereToSpawn = new Vector2(randX, randY);
                GameObject spawnAnimal = Instantiate(animal, randomInCircle, Quaternion.identity) as GameObject;
                spawnAnimal.transform.SetParent(this.transform, false);
                AnimalList.Add(spawnAnimal);
                No++;
            }



        }

        for (int i = 0; i < AnimalList.Count; i++)
        {
            if (AnimalList[i] == null)
            {
                AnimalList.RemoveAt(i);
            }
        }
        //}
    }
}
