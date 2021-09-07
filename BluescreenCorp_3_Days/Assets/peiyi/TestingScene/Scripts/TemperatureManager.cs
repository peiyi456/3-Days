using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemperatureManager : MonoBehaviour
{
    public static TemperatureManager instance;

    [SerializeField] TextMeshProUGUI temperatureTxt;
    public int temperatureValue;
    public int hoursNum;
    public bool isHot;
    public bool isCold;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hoursNum = DayTimeManager.instance.hours - 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if(DayTimeManager.instance.hours == 8)
        //{
        //    hoursNum = 8;
        //    temperatureValue = Random.Range(36, 40);
        //}

        if (DayTimeManager.instance.hours >= 7 && DayTimeManager.instance.hours < 12)
        {
            if (DayTimeManager.instance.hours > hoursNum)
            {
                temperatureValue = Random.Range(36, 41);
                //temperatureValue = 38;
                hoursNum = DayTimeManager.instance.hours;
            }
        }

        else if(DayTimeManager.instance.hours == 12)
        {
            temperatureValue = Random.Range(40, 43);
        }

        else if(DayTimeManager.instance.hours >= 13 && DayTimeManager.instance.hours < 19)
        {
            if (DayTimeManager.instance.hours > hoursNum)
            {
                temperatureValue = Random.Range(36, 41);
                hoursNum = DayTimeManager.instance.hours;
            }
        }

        else if(DayTimeManager.instance.hours >= 19 && DayTimeManager.instance.hours <= 23)
        {
            if (DayTimeManager.instance.hours > hoursNum)
            {
                temperatureValue = Random.Range(32, 36);
                hoursNum = DayTimeManager.instance.hours;
            }
        }

        else if(DayTimeManager.instance.hours >= 00 && DayTimeManager.instance.hours < 7)
        {
            if (DayTimeManager.instance.hours > hoursNum)
            {
                temperatureValue = Random.Range(32, 36);
                hoursNum = DayTimeManager.instance.hours;
            }
        }

        temperatureTxt.text = temperatureValue.ToString() + "°C";
    }
}
