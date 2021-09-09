using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeInteract : ToolHit
{
    [Header("Audio clip")]
    [SerializeField] AudioClip itemDropSound;

    [Header("Details")]
    [SerializeField] float staminaUsed;
    [SerializeField] bool isFruitTree;
    [SerializeField] GameObject[] fruitsOnTree;
    public bool ableToInteract;
    [SerializeField] bool cuttable;

    [Header("Checking for use axe to chop")]
    public bool iscuttableTree;
    public GameObject reminder;
    //[SerializeField] GameObject pickUpDrop;

    [Header("Drop item details")]
    [SerializeField] Item[] item;
    [SerializeField] float spread = 0.7f;
    [SerializeField] int itemCountInOneDrop = 1;
    [SerializeField] int dropCount = 5;
    int oriDropCount;

    [Header("Respawn time")]
    public float time;

    [Header("Progress time (if have) and checking")]
    [SerializeField] Slider Slider;
    bool doneProgress = true;

    [SerializeField] ParticleSystem particleEffect;

    private void Start()
    {
        ableToInteract = true;
        oriDropCount = dropCount;
    }

    private void Update()
    {
        if(!cuttable)
        {
            reminder = null;
        }
        else
        {
            if(!iscuttableTree)
            {
                reminder = null;
            }
        }

        if (ableToInteract)
        {
            particleEffect.gameObject.SetActive(true);
        }

        else
        {
            particleEffect.gameObject.SetActive(false);
        }
    }

    public override void Hit()
    {
        if (!cuttable)
        {
            DropItem();
        }

        else
        {
            if (iscuttableTree)
            {
                if (GameManager.instance.hasAxe)
                {
                    reminder.SetActive(false);
                    DropItem();
                }

                else
                {
                    StartCoroutine(ShowReminderText());
                }
            }

            else
            {
                DropItem();
            }
        }
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
                position.z = GameManager.instance.zPositionForPickUp;

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
            Debug.Log("Dedd");
            PlayerStatusManager.instance.PlayerStamina.value -= staminaUsed;
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

    IEnumerator ShowReminderText()
    {
        reminder.SetActive(true);
        yield return new WaitForSeconds(2f);
        reminder.SetActive(false);
    }
}
