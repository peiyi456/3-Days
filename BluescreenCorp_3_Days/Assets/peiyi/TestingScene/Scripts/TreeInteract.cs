using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeInteract : ToolHit
{
    [SerializeField] AudioClip itemDropSound;

    [SerializeField] bool isFruitTree;
    [SerializeField] GameObject[] fruitsOnTree;
    public bool ableToInteract;

    [SerializeField] bool isTree;
    [SerializeField] bool cuttable;
    //[SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.7f;

    [SerializeField] Item[] item;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropCount = 5;
    int oriDropCount;
    public float time;
    bool doneProgress = true;

    [SerializeField] Slider Slider;

    private void Start()
    {
        ableToInteract = true;
        oriDropCount = dropCount;
    }

    private void Update()
    {

    }

    public override void Hit()
    {
        DropItem();
    }

    //IEnumerator ProgressionTime(float time)
    //{

    //    //progressPercentage.text = "Loading...  " + percentageNumber.ToString("F0") + "%";

    //    //if (percentageNumber >= 100)
    //    //{
    //    //    StartCoroutine(LoadScene());
    //    //}
    //    doneProgress = false;
    //    yield return new WaitForSeconds(time);
    //    Debug.Log("Hit");
    //    while (dropCount > 0)
    //    {
    //        dropCount -= 1;

    //        Vector3 position = transform.position;
    //        position.x += spread * UnityEngine.Random.value - spread / 2;
    //        position.y += spread * UnityEngine.Random.value - spread / 2;
    //        position.z = -36.34118f;

    //        for (int i = 0; i < item.Length; i++)
    //        {
    //            ItemSpawnManager.instance.SpawnItem(position, item[i], itemCountInOneDrop);
    //        }
    //    }

    //    if (cuttable)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void DropItem()
    {
        if (ableToInteract == true)
        {
            //doneProgress = false;
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
                GameManager.instance.soundEffect.PlayOneShot(itemDropSound);
            }

            if (isFruitTree)
            {
                StartCoroutine(FruitShowHideFunc(time));
            }

            if (cuttable)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator FruitShowHideFunc(float time)
    {
        for (int i = 0; i < fruitsOnTree.Length; i++)
        {
            fruitsOnTree[i].SetActive(false);
        }
        ableToInteract = false;

        yield return new WaitForSeconds(time);
        for(int i = 0; i < fruitsOnTree.Length; i++)
        {
            fruitsOnTree[i].SetActive(true);
        }
        ableToInteract = true;
        dropCount = oriDropCount;
    }
}
