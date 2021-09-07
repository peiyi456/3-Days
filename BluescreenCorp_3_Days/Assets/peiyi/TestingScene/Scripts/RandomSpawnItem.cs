using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItem : MonoBehaviour
{
    [Header("No need assign")]
    [SerializeField] GameObject spawnPrefab;

    [Header("Assign value")]
    [SerializeField] GameObject pickUpObject;
    [SerializeField] Item spawnItem;
    [SerializeField] float respawnTime;
    [SerializeField] float countDownTime;
    Vector3 Position;

    bool canRespawn;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.instance.zPositionForPickUp);
        Position = transform.position;
        SpawnItemFunc(Position, spawnItem, 1);
        canRespawn = false;
        countDownTime = respawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPrefab != null)
        {
            canRespawn = false;
        }

        else
        {
            canRespawn = true;
            spawnPrefab = null;
        }

        if (canRespawn)
        {
            countDownTime -= Time.deltaTime;
            if (countDownTime <= 0)
            {
                SpawnItemFunc(Position, spawnItem, 1);
                canRespawn = false;
                countDownTime = respawnTime;
            }
            //StartCoroutine(RespawnItem(respawnTime));
        }
    }

    //void SpawnItem()
    //{
    //    Vector3 position = transform.position;
    //    position.z = GameManager.instance.zPositionForPickUp;

    //    ItemSpawnManager.instance.SpawnItem(position, spawnItem, 1);
    //}

    void SpawnItemFunc(Vector3 position, Item item, int count)
    {
        spawnPrefab = Instantiate(pickUpObject, position, Quaternion.identity);
        spawnPrefab.transform.SetParent(transform);
        spawnPrefab.GetComponent<PickUpItem>().Set(item, count);

    }

    IEnumerator RespawnItem(float time)
    {
        yield return new WaitForSeconds(time);
        if(canRespawn)
        {
            SpawnItemFunc(Position, spawnItem, 1);
        }
        //canRespawn = false;
    }

}
