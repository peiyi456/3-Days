using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureReminder : MonoBehaviour
{
    [SerializeField] string abnormalName;
    [SerializeField] Image temperatureReminder;
    [SerializeField] Image theObject;
    [SerializeField] int remindTemperature;
    [SerializeField] bool isColdReminder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColdReminder)
        {
            if (TemperatureManager.instance.temperatureValue <= remindTemperature)
            {
                if (theObject == null)
                {
                    theObject = Instantiate(temperatureReminder, this.transform);
                    theObject.name = abnormalName;
                    TemperatureManager.instance.isCold = true;
                    //theObject.transform.parent = this.transform;
                    //outReminder = true;
                }
            }

            else
            {
                if (theObject != null)
                {
                    Destroy(theObject.gameObject);
                    TemperatureManager.instance.isCold = false;
                }
            }
        }

        else
        {
            if (TemperatureManager.instance.temperatureValue >= remindTemperature)
            {
                if (theObject == null)
                {
                    theObject = Instantiate(temperatureReminder, this.transform);
                    theObject.name = abnormalName;
                    //theObject.transform.parent = this.transform;
                    //outReminder = true;
                    TemperatureManager.instance.isHot = true;
                }
            }

            else
            {
                if (theObject != null)
                {
                    Destroy(theObject.gameObject);
                    TemperatureManager.instance.isHot = false;
                }
            }
        }

        
    }
}
