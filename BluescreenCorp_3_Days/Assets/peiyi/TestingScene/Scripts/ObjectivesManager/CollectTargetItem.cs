using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectTargetItem : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] string Description;
    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] int targetAmount;
    [SerializeField] int currentCollectAmount;

    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = Description;
    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < inventory.slots.Count; i++)
        //{
        //    if(inventory.slots[i].item.itemType == "Food")
        //    {
        //        currentCollectAmount +=1;
        //        break;
        //    }
        //}

        if(currentCollectAmount >= targetAmount)
        {
            objectiveText.fontStyle = FontStyles.Strikethrough | FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.green;
            GameManager.instance.Objective3 = true;
        }

        else
        {
            objectiveText.fontStyle = FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.black;
            GameManager.instance.Objective3 = false;
        }
    }
}
