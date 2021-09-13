using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaintainStats : MonoBehaviour
{
    [SerializeField] string Description;
    [SerializeField] Slider FoodStat, WaterStat;
    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] float maintainValue;

    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = Description;
        FoodStat = PlayerStatusManager.instance.PlayerFood;
        WaterStat = PlayerStatusManager.instance.PlayerWater;
    }

    // Update is called once per frame
    void Update()
    {
        if(FoodStat.value > maintainValue && WaterStat.value > maintainValue)
        {
            objectiveText.fontStyle = FontStyles.Strikethrough | FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.blue;
            GameManager.instance.Objective1 = true;
        }
        else
        {
            objectiveText.fontStyle = FontStyles.Bold | FontStyles.Italic;
            objectiveText.color = Color.black;
            GameManager.instance.Objective1 = false;
        }
    }
}
