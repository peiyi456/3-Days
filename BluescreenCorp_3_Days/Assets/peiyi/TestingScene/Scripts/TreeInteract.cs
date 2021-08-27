using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : ToolHit
{
    [SerializeField] bool isTree;
    [SerializeField] bool cuttable;
    //[SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.7f;

    [SerializeField] Item[] item;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropCount = 5;
    public static float time;
    bool doneProgress;

    private void Start()
    {
        time = 5.0f;
    }

    private void Update()
    {
        //if(isTree)
        //{
        //    if
        //}
    }

    public override void Hit()
    {
        //Debug.Log("Hit");
        //while (dropCount > 0)
        //{
        //    dropCount -= 1;

        //    Vector3 position = transform.position;
        //    position.x += spread * UnityEngine.Random.value - spread / 2;
        //    position.y += spread * UnityEngine.Random.value - spread / 2;

        //    ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
        //}

        //if (cuttable)
        //{
        //    Destroy(gameObject);
        //}
        StartCoroutine(ProgressionTime(time));
    }

    IEnumerator ProgressionTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Hit");
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            position.z = -36.34118f;

            for (int i = 0; i < item.Length; i++)
            {
                ItemSpawnManager.instance.SpawnItem(position, item[i], itemCountInOneDrop);
            }
        }

        if (cuttable)
        {
            Destroy(gameObject);
        }
    }
}
